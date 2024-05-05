import json
import requests
import streamlit as st
from annotated_text import annotated_text
from awesome_table import AwesomeTable

st.set_page_config(page_title="Ship-Swift App", page_icon="🧊", layout="wide")

side_bar = st.sidebar

with side_bar:
    side_bar.title("Ship-Swift")
    side_bar.subheader("Shipper List")
    side_bar.write("This is the list of shippers")


main_col, right_col = st.columns([5, 2])

# dummy list of shippers

shippers = [
    {"name": "Shipper 1", "id": 1},
    {"name": "Shipper 2", "id": 2},
    {"name": "Shipper 3", "id": 3},
    {"name": "Shipper 4", "id": 4},
    {"name": "Shipper 5", "id": 5},
]

with main_col:
    main_col.title("Ship-Swift")
    main_col.subheader("Shipper List")
    for shipper in shippers:
        main_col.write(shipper["name"])

    annotated_text(
    "This ",
    ("is", "verb"),
    " some ",
    ("annotated", "adj"),
    ("text", "noun"),
    " for those of ",
    ("you", "pronoun"),
    " who ",
    ("like", "verb"),
    " this sort of ",
    ("thing", "noun"),
    "."
    )

with right_col:
    right_col.title("Quotes 🚀")