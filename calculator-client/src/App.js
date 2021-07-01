import Calculator from './Components/Calculator';
import './App.css';
import axios from 'axios';

function App() {
    axios.defaults.baseURL = 'https://localhost:44327';


  return (
      <div className="App">
          <Calculator></Calculator>
    </div>
  );
}

export default App;
