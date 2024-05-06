import json
import requests
import pandas as pd
import streamlit as st
from annotated_text import annotated_text

# declare variables
BASE_PORT = 5118
BASE_API_URL = f"http://localhost:{BASE_PORT}"
DEFAULT_AUTHOR = "Albert Einstein"

st.set_page_config(page_title="Ship-Swift App", page_icon="🧊", layout="wide")

# helper methods
def render_random_quote():
    response = requests.get(f"{BASE_API_URL}/quotes/random")
    quote = response.json()
    quote_text, quote_author = (quote["content"], quote["author"])
    return render_quote(quote_text, quote_author)

def get_all_shippers():
    response = requests.get(f"{BASE_API_URL}/shippers")
    return response.json()

def get_shipper_shipments(shipper_id: int):
    response = requests.get(f"{BASE_API_URL}/shipment/{shipper_id}")
    return response.json()

def get_grouped_author_quotes(author: str, limit: int = 30):
    response = requests.get(f"{BASE_API_URL}/quotes/{author}?limit={limit}")
    return response.json()

def get_all_authors():
    response = requests.get('https://api.quotable.io/authors')
    data = json.loads(response.text)
    return [author['name'] for author in data['results']]

def render_quote(quote, author):
    st.markdown(f"""
        <div style="font-size:35px; text-align:center;">
                <h2>Ship-Swift</h2>
            <p>
                <strong style="font-size:20px; color:Teal;">Quote: </strong>
                <em>{quote}</em>
            </p>
            <p>- {author}</p>
        </div>
        """, unsafe_allow_html=True)

# main app
main_col, right_col = st.columns([5, 2])

shippers = get_all_shippers()

with main_col:
    render_random_quote()
    main_col.divider()
    st.write("### All shippers:")
    for shipper in shippers:
        shipper_id, shipper_name = (shipper["shipperId"], shipper["shipperName"])
        data_expander = st.expander(f"{shipper_name}")
        with data_expander:
            data = get_shipper_shipments(shipper_id)
            df = pd.json_normalize(data['shipments'])
            df['shipperName'] = data['shipperName']
            df = df.rename(columns={
                'shipmentId': 'shipment_id',
                'shipperName': 'shipper_name',
                'carrier.carrierName': 'carrier_name',
                'shipmentDescription': 'shipment_description',
                'shipmentWeight': 'shipment_weight',
                'shipmentRate.shipmentRateDescription': 'shipment_rate_description'
            })
            df = df[['shipment_id', 'shipper_name', 'carrier_name', 'shipment_description', 'shipment_weight', 'shipment_rate_description']]
            st.write(df)


with right_col:
    default_author_index = get_all_authors().index(DEFAULT_AUTHOR)
    author = st.selectbox("Select Author", get_all_authors(), index=default_author_index)

    quotes = get_grouped_author_quotes(author)
    short_quotes, medium_quotes, long_quotes = (quotes["shortQuotes"], 
    quotes["mediumQuotes"], quotes["longQuotes"])
    
    annotated_text(("short quotes", author))
    for quote in short_quotes:
        right_col.caption(f""":sparkles: _{quote["content"]}_""")

    right_col.divider()

    annotated_text(("medium quotes", author))
    for quote in medium_quotes:
        right_col.caption(f""":star2: _{quote["content"]}_""")

    right_col.divider()

    annotated_text(("long quotes", author))
    for quote in long_quotes:
        right_col.caption(f""":star: _{quote["content"]}_""")

    right_col.divider()
