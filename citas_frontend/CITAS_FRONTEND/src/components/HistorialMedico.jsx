import React, { useState, useEffect } from 'react';
import { NavigationBar } from './NavigationBar';
import { Link } from 'react-router-dom';

export const HistorialMedico = () => {
  const [consultas, setConsultas] = useState([]);
  const [cita, setCita] = useState([]);
  const [user, SetUser] = useState(localStorage.user)

  useEffect(() => {
    const fetchConsultas = async () => {
      try {
        const response = await fetch('https://localhost:7089/api/consulta');
        if (!response.ok) {
          throw new Error('Error al obtener las consultas');
        }
        const data = await response.json();

        const consultasConNombres = await Promise.all(data.data.map(async (consulta) => {
          const nombres = await obtenerNombres(consulta.citaId);
          return {
            ...consulta,
            nombrePaciente: nombres.nombrePaciente,
            nombreDoctor: nombres.nombreDoctor
          };
        }));

        setConsultas(consultasConNombres);
      } catch (error) {
        console.error('Error:', error);
      }
    };

    fetchConsultas();
  }, []);

  const obtenerNombres = async (citaId) => {
    try {
      const response = await fetch(`https://localhost:7089/api/citas/${citaId}`);
      if (!response.ok) {
        throw new Error('Error al obtener los detalles de la cita');
      }
      const cita = await response.json();
      return {
        nombrePaciente: cita.nombrePaciente,
        nombreDoctor: cita.nombreDoctor
      };
    } catch (error) {
      console.error('Error:', error);
      return {
        nombrePaciente: 'Nombre de Paciente Desconocido',
        nombreDoctor: 'Nombre de Doctor Desconocido'
      };
    }
  };

  return (
    <div className="bg-gray-200 min-h-screen">
      <NavigationBar />
      <div className="container mx-auto p-20">
        <h2 className="text-2xl font-bold mb-4 text-gray-800">Historial Médico</h2>
        <ul>
          {consultas.map((consulta) => (
            <li key={consulta.id} className="mb-8 p-4 rounded-lg shadow-md bg-white">
              <div className="font-semibold mb-2 text-gray-800">Paciente: {cita.nombrePaciente}</div>
              <div className="font-semibold mb-2 text-gray-800">Doctor: {cita.nombreDoctor}</div>
              <p className="text-gray-600">Fecha: {consulta.fecha}</p>
              <p className="text-gray-600">Peso: {consulta.peso}</p>
              <p className="text-gray-600">Altura: {consulta.altura}</p>
              <p className="text-gray-600">Antecedentes: {consulta.antecedentes}</p>
              <p className="text-gray-600">Diagnóstico: {consulta.diagnostico}</p>
              <p className="text-gray-600">Medicamento: {consulta.medicamento}</p>
              <p className="text-gray-600">Motivo de la consulta: {consulta.motivoConsulta}</p>
              <p className="text-gray-600">Comentario: {consulta.comentario}</p>
            </li>
          ))}
        </ul>
        <div className="flex justify-center items-center mt-8">
          <Link to="/eventos" className="inline-block bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded-full shadow-md focus:outline-none focus:shadow-outline transition duration-300 ease-in-out">
            Ver Eventos
          </Link>
        </div>

      </div>
    </div>
  );
};
