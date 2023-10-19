import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import App from "./App";

function MyRouter() {
  return (
    <Router>
      <Routes>
        <Route path="/:id" Component={App} />
      </Routes>
    </Router>
  );
}

export default MyRouter;
