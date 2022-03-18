import axios from "axios"
import { useEffect, useState } from "react"
import { API } from "../configuration/api";

function OurReservations(props) {
	const [hospitalId, setHospitalId] = useState("");
	const [reservations, setReservations] = useState([]);
	const [patientName, setPatientName] = useState("");
	const [isSearchButtonEnabled, setSearchButtonEnabled] = useState("");
	const [isLoading, setLoading] = useState(false);
	const [isLoaded, setLoaded] = useState(false);
	
	useEffect(() => {
		if (hospitalId.length === 8)
			setSearchButtonEnabled(true)
		else
			setSearchButtonEnabled(false)
	}, [hospitalId])

	const processSearch = () => {
		setLoaded(false)
		if (hospitalId.length === 8) {
			setLoading(true);
			axios.get(`${API}/Hospital/${hospitalId}/Reservations`)
			.then(response =>{
				setReservations(response.data)
				console.log(reservations);
				setLoading(false);
				setLoaded(true);
			})
			.catch(error => {
				console.log(error)
				setLoading(false)
				setLoaded(false);
			})
		}
	}

	return (
		<>
			<h1>Our Reservations</h1>
			<input type="text"
			value={hospitalId}
			onChange={e => setHospitalId(e.target.value)}
			placeholder="Hospital Id"/>
			<button
			type="button"
			disabled={!isSearchButtonEnabled}
			onClick={() => processSearch()}>Search</button>

			{ isLoading 
				? <div className="loader"></div>
				: isLoaded
			}
			{isLoaded && (
				
				<table>
					<thead>
						<tr>
							<th>Patient Name</th>
							<th>PatientId</th>
							<th>Date and Time</th>
						</tr>
					</thead>
					<tbody>
						{reservations.length === 0 && (
							<tr>
								<td colSpan="3">No reservations.</td>
							</tr>
						)}
						{reservations.length > 0 && (
							reservations.map((reservation, index) => {
								return (
									<tr key={index}>
										<td>{reservation.patient.patientName}</td>
										<td>{reservation.patientId}</td>
										<td>{reservation.reservationDatetime}</td>
									</tr>
								)
							})
						)}
					</tbody>
				</table>
			)}
		</>
	)
}

export default OurReservations