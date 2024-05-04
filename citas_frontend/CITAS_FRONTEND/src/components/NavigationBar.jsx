import React, { useState, useRef } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { RiLogoutBoxRLine } from 'react-icons/ri';

export const NavigationBar = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false); 
  const [showServicesMenu, setShowServicesMenu] = useState(false); 
  const navigate = useNavigate(); 
  const menuTimer = useRef(null); 

  const handleLogout = () => {
    localStorage.clear(); 
    navigate('/login'); 
  };

  const showMenu = () => {
    clearTimeout(menuTimer.current);
    setShowServicesMenu(true);
  };

  const hideMenu = () => {
    menuTimer.current = setTimeout(() => {
      setShowServicesMenu(false);
    }, 200);
  };

  return (
    <nav className="fixed top-0 w-full flex items-center justify-between flex-wrap bg-gray-500 p-4 z-10">
      <div className="flex items-center flex-shrink-0 text-white mr-6">
        <Link to="/">
          <span className="font-semibold text-xl tracking-tight">
            Logo
          </span>
        </Link>
      </div>
      <div>
        <Link
          to="/"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Inicio
        </Link>

        <div
          className="inline-block relative" 
          onMouseEnter={showMenu} 
          onMouseLeave={hideMenu} 
        >
          <Link
            to="/" 
            className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
          >
            Servicios
          </Link>
          {showServicesMenu && ( 
            <div className="font-bold absolute left-0 mt-2 bg-gray-400 rounded-lg shadow-md z-10">
              <Link to="/Dermatologia" className="block px-4 py-2 hover:bg-gray-100 border-b border-gray-200">Dermatologia</Link>
              <Link to="/Examenes Medicos" className="block px-4 py-2 hover:bg-gray-100 border-b border-gray-200">Examenes Medicos</Link>
              <Link to="/Nutricionistas" className="block px-4 py-2 hover:bg-gray-100 border-b border-gray-200">Nutricionistas</Link>
              <Link to="/Pedriatras" className="block px-4 py-2 hover:bg-gray-100 border-b border-gray-200">Pedriatras</Link>
              <Link to="/Psicologia" className="block px-4 py-2 hover:bg-gray-100">Psicologos</Link>
            </div>
          )}
        </div>

        <Link
          to="/todoForm"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Agenda cita
        </Link>


        <Link
          to="/historialCita"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Historial de citas
        </Link>

        <Link
          to="/historialMedico"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Historial médico
        </Link>
        <Link
          to="/eventos"
          className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        >
          Registros
        </Link>
        {isLoggedIn && (
          <Link
            to="/profile"
            className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
          >
            Perfil
          </Link>
        )}
        {(
          <button
            onClick={handleLogout}
            className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mr-4 font-semibold"
          >
            <RiLogoutBoxRLine />
          </button>
        )}
      </div>
    </nav>
  );
};
