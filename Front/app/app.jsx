const ReactDOM = require("react-dom/client");
const React = require("react");
import Objective from "./components/objective.jsx";

ReactDOM.createRoot(document.getElementById("app"))
    .render(
        <div>
            <Objective/>
        </div>
    );
