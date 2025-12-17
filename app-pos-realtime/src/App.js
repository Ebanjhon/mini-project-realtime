import './App.css';
import { Route, Routes } from 'react-router-dom';
import Home from './pages/home';
import Order from './pages/order';
import MainLayout from './components/Layouts/MainLayout';

function App() {
  return (
    <Routes>
      <Route element={<MainLayout />}>
        <Route path="/" element={<Home />} />
        <Route path="/order" element={<Order />} />
      </Route>
    </Routes>
  );
}

export default App;