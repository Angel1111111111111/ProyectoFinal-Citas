import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { NavigationBar } from './NavigationBar';

export const HistorialCitas = () => {
  const [citas, setCitas] = useState([]);
  const [botonTexto, setBotonTexto] = useState('Agendar Cita');

  useEffect(() => {
    const obtenerCitasConNombres = async () => {
      try {
        const response = await fetch('https://localhost:7089/api/citas');
        const data = await response.json();
        if (data.status && Array.isArray(data.data)) {
          const citasConNombres = await Promise.all(data.data.map(async (cita) => {
            const [nombrePaciente, nombreDoctor, motivo] = await Promise.all([
              obtenerNombrePaciente(cita.pacienteId),
              obtenerNombreDoctor(cita.doctorId),
              cita.motivoCita,
              cita.estadoCita
            ]);
            const fecha = new Date(cita.fecha).toLocaleDateString();
            const hora = new Date(cita.fecha).toLocaleTimeString();
            return { ...cita, nombrePaciente, nombreDoctor, fecha, hora, motivo };
          }));
          setCitas(citasConNombres);
        } else {
          console.error('La respuesta de la solicitud fetch no contiene un array en la propiedad "data":', data);
        }
      } catch (error) {
        console.error('Error al obtener las citas:', error);
      }
    };

    obtenerCitasConNombres();
  }, []);

  const cancelarCita = async (idCita) => {
    const confirmacion = window.confirm('¿Estás seguro de que deseas cancelar esta cita?');
    if (!confirmacion) {
      return;
    }

    try {
      const response = await fetch(`https://localhost:7089/api/citas/${idCita}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json'
        },
      });
      if (response.ok) {
        const nuevasCitas = citas.filter(cita => cita.id !== idCita);
        setCitas(nuevasCitas);
      } else {
        console.error('Error al cancelar la cita:', response.statusText);
      }
    } catch (error) {
      console.error('Error al cancelar la cita:', error);
    }
  };

  const obtenerNombrePaciente = async (pacienteId) => {
    try {
      const response = await fetch(`https://localhost:7089/api/pacientes/${pacienteId}`);
      const data = await response.json();
      return data.nombre;
    } catch (error) {
      console.error('Error al obtener el nombre del paciente:', error);
      return 'Nombre del paciente no disponible';
    }
  };

  const obtenerNombreDoctor = async (doctorId) => {
    try {
      const response = await fetch(`https://localhost:7089/api/doctores/${doctorId}`);
      const data = await response.json();
      return data.nombre;
    } catch (error) {
      console.error('Error al obtener el nombre del doctor:', error);
      return 'Nombre del doctor no disponible';
    }
  };

  return (
    <div className='bg-gray-200 min-h-screen'>
      <NavigationBar />
    <div className="container mx-auto p-20">
      <h2 className="text-3xl font-semibold mb-4">Historial de Citas</h2>

      <ul>
        {citas.map((cita) => (
          <li key={cita.id} className="bg-white rounded-lg shadow-md p-6 mb-4">
            <p className="text-lg font-semibold">Paciente: {cita.nombrePaciente}</p>
            <p>Fecha: {cita.fecha}</p>
            <p>Hora: {cita.hora}</p>
            <p>Doctor: {cita.nombreDoctor}</p>
            <p>Motivo: {cita.motivo}</p>
            <button onClick={() => cancelarCita(cita.id)} className="bg-red-500 text-white px-4 py-2 rounded-lg mr-2">Cancelar cita</button>
            <Link
              to={{
                pathname: '/todoForm',
                state: { cita }
              }}
              className="bg-blue-500 text-white px-4 py-2 rounded-lg mr-2"
            >
              {botonTexto}
            </Link>
            <Link
              to={{
                pathname: '/consultation',
                state: {
                  pacienteId: cita.pacienteId,
                  doctorId: cita.doctorId
                }
              }}
              className="bg-green-500 text-white px-4 py-2 rounded-lg"
            >
              Hacer consulta
            </Link>
          </li>
        ))}
      </ul>
    </div>
    </div>
  );
};
