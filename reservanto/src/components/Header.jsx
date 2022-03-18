import { useState } from "react";
import { Link } from "react-router-dom";
import "./Header.css";
function Header(props) {
	const [userMode, setUserMode] = useState("");
	return (
		<header>
			<div className="left-right-container">
				<Link to="/"
				onClick={() => {
					setUserMode("patient")
				}}>Patient</Link>
				<Link to="/"
				onClick={() => {
					setUserMode("hospital")
				}}>Hospital</Link>
			</div>
			<Link to="/">Home</Link>
			{userMode === "patient" && (
				<>
					<Link to="/patient/sign-up">Sign Up</Link>
					<Link to="/patient/my-reservations">My Reservations</Link>
					<Link to="/patient/new-reservation">New Reservation</Link>
				</>
			)}
			{userMode === "hospital" && (
				<>
					<Link to="/hospital/sign-up">Sign Up</Link>
					<Link to="/hospital/our-reservations">Our Reservations</Link>
				</>
			)}
			<span className="copyright">&copy; Reservanto 2.0 2021</span>
		</header>
	)
}

export default Header;