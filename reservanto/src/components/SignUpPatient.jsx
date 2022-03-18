import { useEffect, useState } from "react";
import axios from "axios";
import { API } from "../configuration/api";
function SignUp() {
	const [patientName, setPatientName] = useState("");
	const [patientId, setPatientId] = useState("");
	const [patientEmail, setPatientEmail] = useState("");
	const [isSearchButtonEnabled, setSearchButtonEnabled] = useState(false);

	useEffect(() => {
		console.log(parseInt(patientId))
		if (patientName !== "" && (patientId.length === 9 || patientId.length === 10) && parseInt(patientId) != NaN && patientEmail !== "" && validateEmail(patientEmail))
			setSearchButtonEnabled(true);
		else
			setSearchButtonEnabled(false);
	}, [patientName, patientId, patientEmail])

	const validateEmail = () => {
		const regex = /^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/;
		return regex.test(patientEmail.toLowerCase());
	}

	const signUp = () => {
		if (validateEmail(patientEmail) && !isNaN(parseInt(patientId))) {
			axios.post(`${API}/Patient`, {
				"PatientName": patientName,
				"PatientId": patientId,
				"PatientEmail": patientEmail
			})
			.then(() => {
				alert("Successfully signed up.");
			})
			.catch((error) => {
				console.log(error);
			})
		}
	}

	return (
		<>
			<h1>Sign Up</h1>
			<form
			onSubmit={e => e.preventDefault()}>
				<input
				type="text"
				required
				value={patientName}
				onChange={e => {
					setPatientName(e.target.value);
				}}
				placeholder="Name"/>
				<input
				type="number"
				id="patient-id"
				required
				value={patientId}
				onChange={e => {
					setPatientId(e.target.value);
				}}
				placeholder="Patient ID"/>
				<input
				type="text"
				required
				value={patientEmail}
				onChange={e => {
					setPatientEmail(e.target.value);
				}}
				onBlur={e => {
					validateEmail(e.target.value)
				}}
				placeholder="Email"/>

				<button
				type="submit"
				disabled={!isSearchButtonEnabled}
				onClick={e => {
					signUp();
				}}>Sign Up</button>
			</form>
		</>
	)
}

export default SignUp;