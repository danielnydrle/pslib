import axios from "axios";
import { useState, useEffect, Spinner } from "react";
import { API } from "../configuration/api";
function NewReservation(props) {
	const currentDate = `${new Date().getFullYear()}-${(new Date().getMonth()+1).toString().padStart(2, "0")}-${(new Date().getDate()).toString().padStart(2, "0")}`;
	const [hospitals, setHospitals] = useState([]);
	const [selectedHospital, setSelectedHospital] = useState({});
	const [selectedHospitalId, setSelectedHospitalId] = useState("");
	const [isAddButtonEnabled, setAddButtonAllowed] = useState(false);
	const [isPatientVerified, setPatientVerified] = useState(false);
	const [isDatetimeVerified, setDatetimeVerified] = useState(false);
	const [patientId, setPatientId] = useState();
	const [date, setDate] = useState("");
	const [time, setTime] = useState("");
	const [isLoading, setLoading] = useState(true);

	useEffect(() => { //get all hospitals
		setLoading(true);
		axios.get(`${API}/Hospital`)
		.then((response) => {
			setHospitals(response.data)
			setSelectedHospital(response.data[0]);
			setSelectedHospitalId(response.data[0].hospitalId)
			setLoading(false);
		})
		.catch(error => {
			console.log(error)
		})
	}, [])

	useEffect(() => {
		axios.get(`${API}/Hospital/${selectedHospitalId}`)
		.then(response => {
			setSelectedHospital(response.data)
		})
	}, [selectedHospitalId])

	useEffect(() => { //allow/disable send button
		let isVerified = isPatientVerified && isDatetimeVerified ? true : false;
		setAddButtonAllowed(isVerified);
	}, [isPatientVerified, isDatetimeVerified])

	useEffect(() => {
		verifyPatient();
	}, [patientId])
	
	useEffect(() => {
		verifyDatetime();
	}, [date, time])

	const handleSelect = (id) => {
		setLoading(true);
		axios.get(`${API}/Hospital/${id}`)
		.then(response => {
			setSelectedHospital(response.data);
			setLoading(false);
		})
		.catch(error => {
			console.log(error)
		})
	}


	const verifyPatient = () => {
		console.log(patientId);
		console.log(`${API}/Patient/${patientId}`)
		axios.get(`${API}/Patient/${patientId}`)
		.then(() => {
			setPatientVerified(true);
		})
		.catch((error) => {
			setPatientVerified(false);
		})
	}

	const verifyDatetime = () => {
		let datetime = `${date} ${time}`;
		if (date !== ("" || undefined) && time !== ("" || undefined)) {
			let reservationHour = parseInt(time.substr(0, 2));
			let reservationMinute = parseInt(time.substr(-2, 2));
			if (reservationHour >= selectedHospital.hospitalOpen && reservationHour < selectedHospital.hospitalClose && (reservationMinute % 5 === 0)) {
				axios.get(`${API}/Hospital/${selectedHospital.hospitalId}/Reservations/Available/${datetime}`)
				.then((response) => {
					setDatetimeVerified(true);
				})
				.catch(error => {
					setDatetimeVerified(false);
					console.log(error);
				})
			}
			else {
				setDatetimeVerified(false);
			}
		}
		else {
			setDatetimeVerified(false);
		}
	}

	const addReservation = () => {
		axios.post(`${API}/Reservation`, {
			"ReservationDatetime": `${date} ${time}`,
			"PatientId": patientId,
			"HospitalId": selectedHospital.hospitalId })
		.then((response) => {
			console.log(response)
			setDate("");
			setTime("");
		})
		.catch((error) => {
			console.log(error)
		})
	}
	return isLoading
	? <div className="loader"></div>
	: (
		<>
			<h1>New Reservation</h1>
			<select
				value={selectedHospitalId}
				onChange={e => {
					handleSelect(e.target.value)
					setSelectedHospitalId(e.target.value)
				}}>
					{hospitals.map((hospital, index) => {
						return (
							<option key={index} value={hospital.hospitalId}>
								{hospital.hospitalName}
							</option>
						)
					})}
			</select>
			{isLoading && <div className="loader"></div>}
			<form
			method="post"
			onSubmit={e => e.preventDefault()}>
				<label htmlFor="reservation-patientid">Patient ID</label>
				<input
					type="text"
					name="reservation-patientid"
					value={patientId}
					onChange={e => setPatientId(e.target.value)} />
				<label htmlFor="reservation-date">Date</label>
				<input
					type="date"
					name="reservation-date"
					min={currentDate}
					value={date}
					onChange={e => setDate(e.target.value)} />
				<label htmlFor="reservation-time">Time ({`${selectedHospital.hospitalOpen}:00`}-{selectedHospital.hospitalClose-1}:55)</label>
				<input
					type="time"
					step="300"
					name="reservation-time"
					min={`${selectedHospital.hospitalOpen}:00`}
					max={`${selectedHospital.hospitalClose-1}:55`}
					value={time}
					onChange={e => setTime(e.target.value)} />
				<button type="submit"
				disabled={!isAddButtonEnabled}
				onClick={e => {
					addReservation();
				}}>Add Reservation</button>
			</form>
		</>
	)
}

export default NewReservation;