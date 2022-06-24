import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { ApplicationUIControllerProvider } from "./context";

ReactDOM.render(
  <BrowserRouter>
    <ApplicationUIControllerProvider>
      <App />
    </ApplicationUIControllerProvider>
  </BrowserRouter>,
  document.getElementById("root")
);

reportWebVitals();
