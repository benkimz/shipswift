# 🚀 ShipSwift

**ShipSwift** is an application that integrates a C# backend with a Python frontend, seamlessly working with an SQLite database to manage:

- **Shippers**
- **Shipments**
- **Carriers**
- **ShipmentRate**

With ShipSwift, you can easily query data, fetch quotes from the Quotes API, and interact with a user-friendly interface built with Streamlit. The interface allows you to search quotes by author name, neatly grouping results by length: short, medium, and long.

## 🚀 Quick Start

### Step 1: Clone the Repository

Clone the ShipSwift repository and navigate to the project directory:

```bash
git clone https://github.com/benkimz/shipswift.git
cd shipswift/src/
```

### Step 2: Setup and Launch the Backend & Frontend

**For Windows, macOS, and Linux:**

1. Open a terminal in the `frontend/api/ShipSwift.Api` directory and run:

   ```bash
   dotnet watch run
   ```

2. In a new terminal, navigate to the `frontend/web` directory and install the necessary Python dependencies:

   ```bash
   pip install -r requirements.txt
   ```

3. Launch the frontend application:

   ```bash
   streamlit run app.py
   ```

And that's it! ShipSwift is now up and running.

![Demo Image](https://raw.githubusercontent.com/benkimz/shipswift/main/demo.png)
