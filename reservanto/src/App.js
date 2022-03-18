import './App.css';
import { useState, useEffect } from "react";
import { Route, Switch, useHistory } from "react-router";
import { BrowserRouter } from "react-router-dom";
import { createBrowserHistory } from "history";
import Header from "./components/Header";
import Content from "./components/Content";
import Homepage from "./components/Homepage";
import MyReservations from "./components/MyReservations";
import ReservationDetail from './components/ReservationDetail';
import NewReservation from "./components/NewReservation";
import SignUpPatient from "./components/SignUpPatient";
import SignUpHospital from "./components/SignUpHospital";
import OurReservations from './components/OurReservations';

const history = createBrowserHistory();

function App() {
	const [isDarkTheme, setDarkTheme] = useState(false);

	const toggleDarkTheme = () => {
		setDarkTheme(!isDarkTheme);
		
	}

	return (
		<div className={`App ${isDarkTheme ? "dark" : "light"}`}>
			<BrowserRouter history={history}>
				<Header />
				<Content callbackChangeTheme={toggleDarkTheme}>
					<Switch>
						<Route exact path="/" component={Homepage} />
						<Route exact path="/reservation-detail/:id" component={ReservationDetail} />
						<Route exact path="/patient/my-reservations" component={MyReservations} />
						<Route exact path="/patient/new-reservation" component={NewReservation} />
						<Route exact path="/patient/sign-up" component={SignUpPatient} />
						<Route exact path="/hospital/sign-up" component={SignUpHospital} />
						<Route exact path="/hospital/our-reservations" component={OurReservations} />
					</Switch>
				</Content>
			</BrowserRouter>
		</div>
	);
}

export default App;
