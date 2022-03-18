import { useState, useEffect } from "react";
import axios from "axios";
import { API } from "../configuration/api";
import { useParams } from "react-router-dom";

function ReservationDetail() {
	const { id } = useParams();
	const [isLoading, setLoading] = useState(true);
	const [data, setData] = useState({});
	useEffect(() => {
		setLoading(true);
		axios.get(`${API}/Reservation/${id}`)
		.then((response) => {
			setData(response.data);
			setLoading(false);
		})
		.catch(() => {
			// redirect
		})
	}, [])
	return (
		<>
		<h1>Reservation</h1>
		{ isLoading
		? <div className="loader"></div>
		: <>
			<img src={`https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=${data.reservationId}`} />
			<table>
				<tr>
					<td>Date and time</td>
					<td>{data.reservationDatetime}</td>
				</tr>
				<tr>
					<td>Patient ID</td>
					<td>{data.patientId}</td>
				</tr>
				<tr>
					<td>Hospital ID</td>
					<td>{data.hospitalId}</td>
				</tr>
			</table>
		</>
		}
		
		</>
	)
}

export default ReservationDetail;