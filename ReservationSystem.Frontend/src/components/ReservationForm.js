import React, { useState } from "react";
import axios from "axios";

const ReservationForm = () => {
  const [formData, setFormData] = useState({
    roomId: "",
    dateFrom: "",
    dateTo: "",
    numberOfPeople: "",
  });

  const [successMessage, setSuccessMessage] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const handleChange = (event) => {
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (formData.numberOfPeople <= 0) {
      setSuccessMessage("");
      setErrorMessage("The number of people must be greater than 0.");
      return;
    }

    try {
      const response = await axios.post(
        "http://localhost:5157/api/Reservations",
        formData
      );

      setSuccessMessage("Reservation created successfully");
      setErrorMessage("");
    } catch (error) {
      alert(`Error: ${JSON.stringify(error.response.data)}`);
      setSuccessMessage("");
      setErrorMessage("");
    }
  };

  return (
    <div>
      {successMessage && <p>{successMessage}</p>}
      {errorMessage && <p>{errorMessage}</p>}
      <form onSubmit={handleSubmit}>
        <label>
          Room number:
          <input
            type="text"
            name="roomId"
            value={formData.roomId}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Date from:
          <input
            type="date"
            name="dateFrom"
            value={formData.dateFrom}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Date to:
          <input
            type="date"
            name="dateTo"
            value={formData.dateTo}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Number of people:
          <input
            type="number"
            name="numberOfPeople"
            value={formData.numberOfPeople}
            onChange={handleChange}
          />
        </label>
        <br />
        <input type="submit" value="Submit" />
      </form>
    </div>
  );
};

export default ReservationForm;
