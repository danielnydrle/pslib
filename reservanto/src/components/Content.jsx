import "./Content.css";
function Content(props) {
	return (
		<div id="content">
		<button
		id="toggleDarkMode"
		onClick={() => {
			props.callbackChangeTheme()
		}}></button>
		{props.children}
		</div>
	)
}

export default Content;