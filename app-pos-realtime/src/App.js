import './App.css';
import { Route, Routes } from 'react-router-dom';
import Home from './pages/home';
import Order from './pages/order';
import MainLayout from './components/Layouts/MainLayout';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <>
      <Routes>
        <Route element={<MainLayout />}>
          <Route path="/" element={<Home />} />
        </Route>
        <Route path="/order" element={<Order />} />
      </Routes>
      <ToastContainer
        position="top-right"
        autoClose={2000}
        newestOnTop
        pauseOnHover
      />
    </>
  );
}

export default App;