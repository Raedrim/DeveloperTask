import React, { useState } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";

const ReservationForm = ({ roomId, rooms }) => {
  const [formData, setFormData] = useState({
    dateFrom: "",
    dateTo: "",
    numberOfPeople: "",
  });

  const [successMessage, setSuccessMessage] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  //we find which room is selected
  const room = rooms.find((room) => room.id === roomId);

  const handleChange = (event) => {
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

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
      <Form onSubmit={handleSubmit}>
        <p>Room: {room.name}</p>
        <Form.Group controlId="formDateFrom">
          <Form.Label>Date from:</Form.Label>
          <Form.Control
            type="date"
            name="dateFrom"
            value={formData.dateFrom}
            onChange={handleChange}
          />
        </Form.Group>
        <Form.Group controlId="formDateTo">
          <Form.Label>Date to:</Form.Label>
          <Form.Control
            type="date"
            name="dateTo"
            value={formData.dateTo}
            onChange={handleChange}
          />
        </Form.Group>
        <Form.Group controlId="formNumberOfPeople">
          <Form.Label>Number of people:</Form.Label>
          <Form.Control
            type="number"
            name="numberOfPeople"
            value={formData.numberOfPeople}
            onChange={handleChange}
          />
        </Form.Group>
        <Button variant="primary" type="submit">
          Reserve
        </Button>
      </Form>
    </div>
  );
};

export default ReservationForm;
