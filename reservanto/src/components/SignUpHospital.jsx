import axios from "axios";
import { useEffect, useState } from "react";
import { API } from "../configuration/api";

function SignUpHospital(props) {
	const [hospitalName, setHospitalName] = useState("");
	const [hospitalId, setHospitalId] = useState("");
	const [hospitalOpen, setHospitalOpen] = useState(0);
	const [hospitalClose, setHospitalClose] = useState(0);
	const [isSignupButtonEnabled, setSignupButtonEnabled] = useState(false);

	useEffect(() => {
		if
		(hospitalName !== "" && hospitalOpen < hospitalClose) {
			setSignupButtonEnabled(true)
		}
	}, [hospitalName, hospitalId, hospitalOpen, hospitalClose])

	const signUp = () => {
		console.log("signup")
		console.log(hospitalName)
		console.log(hospitalId)
		console.log(hospitalOpen)
		console.log(hospitalClose)
		if
		(
			hospitalName !== "" &&
			hospitalOpen < hospitalClose
		) {
			axios
			.post((`${API}/Hospital`), {
				"HospitalName": hospitalName,
				"HospitalId": hospitalId,
				"HospitalOpen": hospitalOpen.toString(),
				"HospitalClose": hospitalClose.toString()
			})
			.then(response => {
				console.log(response)
			})
			.catch(error => {
				console.log(error)
			})
		}
		
	}
	return (
		<>
			<h1>Sign Up</h1>
			<form action="">
				<input
				type="text"
				required
				name="hospital-name"
				value={hospitalName}
				onChange={e => setHospitalName(e.target.value)}
				placeholder="Name"/>
				<input
				type="text"
				required
				name={"hospital-id"}
				value={hospitalId}
				onChange={e => setHospitalId(e.target.value)}
				placeholder="Hospital ID"/>
				<label htmlFor="hospital-open">Open</label>
				<input
				type="number"
				required
				name="hospital-open"
				value={hospitalOpen}
				onChange={e => setHospitalOpen(e.target.value)}
				min="0"
				max="23"
				placeholder="Open"/>
				<label htmlFor="hospital-close">Close</label>
				<input
				type="number"
				required
				name="hospital-close"
				value={hospitalClose}
				onChange={e => setHospitalClose(e.target.value)}
				min={parseInt(hospitalOpen) + 1}
				max="24"
				placeholder="Close"/>
				<button
				type="submit"
				disabled={!isSignupButtonEnabled}
				onClick={signUp()}>Sign Up</button>

			</form>
			<p></p>
		</>
	)
}

export default SignUpHospital