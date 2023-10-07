import { BrowserRouter, Route, Routes } from "react-router-dom"
import Header from "./components/Header"
import Landing from "./pages/Landing"
import Footer from "./components/Footer"
import Login from "./pages/Login"
import SignUp from "./pages/SignUp"

function App() {
	return (
		<BrowserRouter>
			<Header />
			<Routes>
				<Route path="/" Component={Landing} />
				<Route path="/login" Component={Login} />
				<Route path="/sign-up" Component={SignUp} />
			</Routes>
			<Footer />
		</BrowserRouter>
	)
}

export default App
