import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { NavigationBar } from './NavigationBar';

export const TodoFormCita = ({ onCitaAgendada }) => {
    const [pacientes, setPacientes] = useState([]);
    const [doctores, setDoctores] = useState([]);
    const [formData, setFormData] = useState({
        pacienteId: '',
        doctorId: '',
        fecha: '',
        motivoCita: '',
        estado: false,
    });
    const [editandoCita, setEditandoCita] = useState(false); 
    const location = useLocation();

    useEffect(() => {
        fetch('https://localhost:7089/api/pacientes')
            .then(response => response.json())
            .then(data => setPacientes(data));

        fetch('https://localhost:7089/api/doctores')
            .then(response => response.json())
            .then(data => setDoctores(data));

        if (location.state) {
            const { doctorId, pacienteId, fecha, motivoCita } = location.state;
            setFormData({
                ...formData,
                doctorId,
                pacienteId,
                fecha,
                motivoCita,
            });
            setEditandoCita(true); 
        }
    }, [location.state]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch('https://localhost:7089/api/citas', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });
            if (response.ok) {
                const nuevaCita = await response.json();
                console.log('Cita guardada:', nuevaCita);
                if (onCitaAgendada) {
                    onCitaAgendada(nuevaCita);
                }
                setFormData({
                    pacienteId: '',
                    doctorId: '',
                    fecha: '',
                    motivoCita: '',
                    estado: false,
                });
                window.location.href = '/historialCita';
            } else {
                console.error('Error al guardar la cita:', response.statusText);
            }
        } catch (error) {
            console.error('Error al enviar la cita:', error);
        }
    };

    return (
        <div className='bg-gray-200 min-h-screen'>
            <NavigationBar />
            <div className="flex justify-center items-center h-screen">
                <form onSubmit={handleSubmit} className="bg-gray-100 p-8 rounded-lg shadow-lg">
                    <h2 className="text-gray-800 text-2xl font-bold mb-4">{editandoCita ? 'Editar Cita' : 'Agendar Cita'}</h2>

                    <label htmlFor="pacienteId" className="block text-gray-800 mb-2">Paciente:</label>
                    <select
                        name="pacienteId"
                        id="pacienteId"
                        value={formData.pacienteId}
                        onChange={handleChange}
                        className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
                    >
                        <option value="">Selecciona un paciente</option>
                        {pacientes.map(paciente => (
                            <option key={paciente.id} value={paciente.id}>{paciente.nombre}</option>
                        ))}
                    </select>

                    <label htmlFor="doctorId" className="block text-gray-800 mb-2">Doctor:</label>
                    <select
                        name="doctorId"
                        id="doctorId"
                        value={formData.doctorId}
                        onChange={handleChange}
                        className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
                    >
                        <option value="">Selecciona un doctor</option>
                        {doctores.map(doctor => (
                            <option key={doctor.id} value={doctor.id}>{doctor.nombre}</option>
                        ))}
                    </select>

                    <label htmlFor="fecha" className="block text-gray-800 mb-2">Fecha:</label>
                    <input
                        type="datetime-local"
                        name="fecha"
                        value={formData.fecha}
                        onChange={handleChange}
                        className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
                    />

                    <label htmlFor="motivoCita" className="block text-gray-800 mb-2">Motivo de la Cita:</label>
                    <input
                        type="text"
                        name="motivoCita"
                        value={formData.motivoCita}
                        onChange={handleChange}
                        className="w-full px-4 py-2 mb-4 rounded-lg bg-gray-200 text-gray-800 focus:outline-none focus:ring focus:border-gray-600"
                    />

                    <button
                        type="submit"
                        className="w-full bg-gray-700 text-white py-2 rounded-lg hover:bg-gray-800 focus:outline-none focus:ring focus:border-gray-600"
                    >
                        {editandoCita ? 'Editar Cita' : 'Agendar Cita'}
                    </button>

                    <div className="flex justify-center items-center py-2">
                        <Link to="/historialCita" className="w-full text-center bg-blue-700 text-white py-2 rounded-lg hover:bg-blue-800 focus:outline-none focus:ring focus:border-gray-600">
                            Historial de Citas
                        </Link>
                    </div>

                </form>
            </div>
        </div>
    );
};
