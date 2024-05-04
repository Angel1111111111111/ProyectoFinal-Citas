import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { constants } from '../helpers/constants';
import { NavigationBar } from '../components';

export const Psychology = () => {
    const [doctorInfo, setDoctorInfo] = useState([]);
    const { API_URL } = constants();
    const especialidadId = '08dc63c5-f0ae-4cd4-85ed-d6654c1d3b6b';

    useEffect(() => {
        const fetchData = async () => {
            try {
                const responseDoctors = await fetch(`${API_URL}/doctores/especialidad/${especialidadId}`);
                const responseTurnos = await fetch(`${API_URL}/doctores/turnos`);

                if (!responseDoctors.ok || !responseTurnos.ok) {
                    throw new Error('Error al obtener datos');
                }

                const dataDoctors = await responseDoctors.json();
                const dataTurnos = await responseTurnos.json();

                const turnos = dataTurnos.reduce((acc, turno) => {
                    acc[turno.id] = turno;
                    return acc;
                }, {});

                const doctorsWithTurnos = dataDoctors.map(doctor => ({
                    ...doctor,
                    turno: turnos[doctor.turnoId]
                }));

                setDoctorInfo(doctorsWithTurnos);
            } catch (error) {
                console.error('Error al obtener datos:', error);
            }
        };

        fetchData();
    }, [API_URL, especialidadId]); 

    const formatDateForURL = (dateString) => {
        if (!dateString) {
            return ''; 
        }
        const dateObject = new Date(dateString);
        return `${dateObject.getFullYear()}-${(dateObject.getMonth() + 1).toString().padStart(2, '0')}-${dateObject.getDate().toString().padStart(2, '0')}`;
    };

    return (
        <div className='bg-gray-300 h-screen'>
            <NavigationBar />
            <div className="container mx-auto">
                <h1 className="text-3xl font-bold mb-6 text-center p-5">Lista de Doctores Psicólogos</h1>
                <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 px-6">
                    {doctorInfo.map((doctor, index) => (
                        <div key={index} className="bg-white p-4 rounded-lg shadow-md">
                            <h2 className="text-xl font-semibold text-blue-500 mb-2">{doctor.nombre}</h2>
                            {doctor.turno && (
                                <div className="mb-4">
                                    <p className="font-semibold">Turno:</p>
                                    <p><span className="font-semibold">Hora de inicio:</span> {doctor.turno.horaInicio}</p>
                                    <p><span className="font-semibold">Hora de fin:</span> {doctor.turno.horaFin}</p>
                                </div>
                            )}
                            <div className="flex justify-between">
                                <Link
                                    to={{
                                        pathname: '/todoForm',
                                        state: {
                                            doctorId: doctor.id,
                                            pacienteNombre: doctor.pacienteNombre,
                                        }
                                    }}
                                    className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded inline-block"
                                >
                                    Agendar Cita
                                </Link>
    
                                <Link
                                    //to={`/perfilDoctor/${doctor.id}`} // Ruta a la página de perfil del doctor
                                    className="bg-gray-300 hover:bg-gray-400 text-gray-800 font-bold py-2 px-4 rounded inline-block"
                                >
                                    Ver Perfil
                                </Link>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );    
};
