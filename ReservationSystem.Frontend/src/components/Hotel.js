import React, { useState, useEffect } from "react";
import axios from "axios";
import ReservationForm from "./ReservationForm";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Table from "react-bootstrap/Table";

const Hotel = () => {
  const [rooms, setRooms] = useState([]);
  const [selectedRoomId, setSelectedRoomId] = useState(null);
  const [showModal, setShowModal] = useState(false);

  // Fetch all available rooms on component mount
  useEffect(() => {
    axios.get("http://localhost:5157/api/Rooms").then((response) => {
      setRooms(response.data);
    });
  }, []);

  // Handler for when a room is clicked on the table
  const handleRoomClick = (roomId) => {
    setSelectedRoomId(roomId);
    setShowModal(true);
  };

  // Handler for closing the modal
  const handleCloseModal = () => {
    setShowModal(false);
  };

  return (
    <div>
      <h1>Available Rooms</h1>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Room Name</th>
            <th className="text-center">Quantity</th>
            <th className="text-center">Action</th>
          </tr>
        </thead>
        <tbody>
          {rooms.map((room) => (
            <tr key={room.id} onClick={() => handleRoomClick(room.id)}>
              <td>{room.name}</td>
              <td className="text-center">{room.numberOfPeople}</td>
              <td className="text-center">
                <Button variant="primary">Reserve</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      {/* Modal for making a reservation */}
      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title className="text-center w-100">
            Reserve
            {/* Close button in the top right corner */}
            <Button
              variant="link"
              className="position-absolute top-0 end-0"
              onClick={handleCloseModal}
            >
              <i className="bi bi-x-lg"></i>
            </Button>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <ReservationForm roomId={selectedRoomId} />
        </Modal.Body>
      </Modal>
    </div>
  );
};

export default Hotel;
