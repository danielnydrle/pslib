import axios from "axios";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { API } from "../configuration/api";

function MyReservations(props) {
	const [reservations, setReservations] = useState([]);
	const [patientId, setpatientId] = useState("");
	const [isSearchButtonEnabled, setSearchButtonEnabled] = useState(false);
	const [isLoading, setLoading] = useState(false);
	const [isLoaded, setLoaded] = useState(false);

	useEffect(() => {
		if (patientId.length === 9 || patientId.length === 10)
			setSearchButtonEnabled(true);
		else
			setSearchButtonEnabled(false)
	}, [patientId])

	const processSearch = () => {
		setReservations([]);
		setLoading(true);
		axios.get(`${API}/Patient/${patientId}/Reservations`)
		.then(response => {
			console.log(response.status);
			setReservations(response.data);
			setLoading(false);
			setLoaded(true);
		})
		.catch(error => {
			console.log(error);
			setLoading(false);
			setLoaded(false);
		})
}

	const getHospitalName = (id) => {
		axios.get(`${API}/Hospital/${id}`)
		.then(response => {
			console.log(response.data);
			return response.data.hospitalName;
		})
		.catch(error => {
			console.log(error);
		})
	}

	const deleteReservation = (id) => {
		let _confirm = window.confirm("Do you really want to delete this reservation?");
		if (_confirm) {
			axios.delete(`${API}/Reservation/${id}`)
			.then(() => {
				alert("Reservation was deleted.");
			})
			.catch(error => {
				console.log(error);
			})
			.then(() => {
				processSearch();
			})
		}
	}

	return (
		<>
		<h1>My Reservations</h1>
		<input
			type="text"
			value={patientId}
			placeholder="Patient ID"
			onChange={e => {
				setpatientId(e.target.value)
			}}/>
		<button
		type="button"
		disabled={!isSearchButtonEnabled}
		onClick={e => {
			processSearch();
		}}>Search</button>
		{ isLoading
		? <div className="loader"></div>
		: isLoaded && (
			<table>
				<thead>
					<tr>
						<th>Hospital</th>
						<th>Date and Time</th>
						<th>Checkout</th>
						<th>Delete</th>
					</tr>
				</thead>
				<tbody>
					{reservations.length > 0
					? reservations.map((reservation, index) => {
						return (
							<tr key={index}>
								<td>{reservation.hospital.hospitalName}</td>
								<td>{reservation.reservationDatetime}</td>
								<td>
									<Link to={`/reservation-detail/${reservation.reservationId}`}>Open</Link>	
								</td>
								<td><button onClick={e => deleteReservation(reservation.reservationId)}>Delete</button></td>
							</tr>
						)
					})
					: (<tr>
						<td colSpan="4">No reservations.</td>
					</tr>)}
				</tbody>
			</table>
		) }
		</>
	)
}

export default MyReservations;