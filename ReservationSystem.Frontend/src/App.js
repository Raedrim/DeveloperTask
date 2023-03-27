import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Hotel from "./components/Hotel";
import ReservationForm from "./components/ReservationForm";

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<Hotel />}></Route>
          <Route path="reservation/:roomId" element={<ReservationForm/>} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;