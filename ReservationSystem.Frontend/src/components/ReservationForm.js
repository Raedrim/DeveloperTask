import React, { useState } from "react";
import axios from "axios";
import "./reservationForm.css";

const ReservationForm = ({ roomId, handleReservationSuccess }) => {
  const [formData, setFormData] = useState({
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
        {
          roomId,
          dateFrom: formData.dateFrom,
          dateTo: formData.dateTo,
          numberOfPeople: formData.numberOfPeople,
        }
      );

      setSuccessMessage("Reservation created successfully");
      console.log(
        `EMAIL SENT TO test@admin.com FOR CREATED Reservation WITH ID ${response.data.id}`
      );
      setErrorMessage("");
    } catch (error) {
      if (error.response && error.response.data) {
        alert(`Error: ${JSON.stringify(error.response.data)}`);
      } else {
        alert("An error occurred while submitting the reservation.");
      }
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
