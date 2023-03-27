import React, { useState, useEffect } from "react";
import axios from "axios";
import ReservationForm from "./ReservationForm";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import "./hotel.css";

const Hotel = () => {
  const [rooms, setRooms] = useState([]);
  const [selectedRoomId, setSelectedRoomId] = useState(null);
  const [showModal, setShowModal] = useState(false);

  useEffect(() => {
    // Fetch all available rooms
    axios.get("http://localhost:5157/api/Rooms").then((response) => {
      setRooms(response.data);
    });
  }, []);

  const handleRoomClick = (roomId) => {
    setSelectedRoomId(roomId);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };

  return (
    <div>
      <h1>Available Rooms</h1>
      <table>
        <thead>
          <tr>
            <th>Room Name</th>
            <th>Quantity</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {rooms.map((room) => (
            <tr key={room.id} onClick={() => handleRoomClick(room.id)}>
              <td>{room.name}</td>
              <td>{room.numberOfPeople}</td>
              <td>
                <button>Reserve</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header>
          <Modal.Title className="text-center w-100">Reserve</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <ReservationForm roomId={selectedRoomId} />
        </Modal.Body>
      </Modal>
    </div>
  );
};

export default Hotel;
