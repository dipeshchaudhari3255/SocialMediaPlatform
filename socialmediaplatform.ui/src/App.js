
import './App.css';
import Login from './components/Login';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import Register from './components/Register';
import ForgotPassword from './components/ForgotPassword';
import OTP from './components/OTP';



function App() {
  return (
    <Router>
      <div className="App">
        <nav className="navbar navbar-expand-lg navbar-light">
          <div className="container">
            <Link className="navbar-brand" to={'/'}>
              Social Media Platform
            </Link>
            <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
              <ul className="navbar-nav ml-auto">
                <li className="nav-item">
                  <Link className="nav-link" to={'/'}>
                    Login
                  </Link>
                </li>
                <li className="nav-item">
                    <Link className="nav-link" to={'/Register'}>
                      Register
                    </Link>
                </li>
              </ul>
            </div>
          </div>
        </nav>

        <div className="auth-wrapper">
          <div className="auth-inner">
            <Routes>
              <Route exact path="/" element={<Login />} />
              <Route path="/" element={<Login />} />
              <Route path="/Register" element={<Register />} />
              <Route path="/ForgotPassword" element={<ForgotPassword />} />
              <Route path="/OTP" element={<OTP />} />
            </Routes>
          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;
