import React, { useState, useEffect } from 'react';
import { NavigationBar } from './NavigationBar';

export const HistorialMedico = () => {
  const [consultas, setConsultas] = useState([]);

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
              <div className="font-semibold mb-2 text-gray-800">Paciente: {consulta.nombrePaciente}</div>
              <div className="font-semibold mb-2 text-gray-800">Doctor: {consulta.nombreDoctor}</div>
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
      </div>
    </div>
  );
};
