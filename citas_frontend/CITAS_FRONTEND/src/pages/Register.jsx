import React, { useState } from 'react';
import { NavigationBar } from '../components';
import { InputEmailValidation } from '../validation/input-email';
import { InputRequiredValidation } from '../validation/input-required';
import { useNavigate } from 'react-router-dom';
import { constants } from '../helpers/constants';

export const Register = () => {
    const [formData, setFormData] = useState({
        nombre: '',
        identidad: '',
        telefono: '',
        correoElectronico: '',
        contraseña: '',
        repetirContraseña: '',
        genero: ''
    });
    const [errors, setErrors] = useState([]);
    const navigate = useNavigate();
    const { API_URL } = constants();

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        let newErrors = [];

        const errorEmail = InputEmailValidation('Correo Electrónico', formData.correoElectronico);
        if (!errorEmail.validation) {
            newErrors.push(errorEmail.message);
        }

        const errorEmailRequired = InputRequiredValidation('Correo Electrónico', formData.correoElectronico);
        if (!errorEmailRequired.validation) {
            newErrors.push(errorEmailRequired.message);
        }

        const errorPasswordRequired = InputRequiredValidation('Contraseña', formData.contraseña);
        if (!errorPasswordRequired.validation) {
            newErrors.push(errorPasswordRequired.message);
        }

        if (formData.contraseña !== formData.repetirContraseña) {
            newErrors.push('Las contraseñas no coinciden');
        }

        setErrors(newErrors);

        if (newErrors.length === 0) {
            try {
                const response = await fetch(`${API_URL}/pacientes/register`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(formData)
                });

                if (response.ok) {
                    console.log('Registro exitoso');
                    navigate(`/agendar-cita?doctor=${encodeURIComponent(formData.nombre)}&paciente=${encodeURIComponent(formData.nombre)}`);
                } else {
                    console.error('Error al registrar', response);
                }
            } catch (error) {
                console.error('Error de red:', error);
            }
        }
    };


    const generos = ["Masculino", "Femenino", "Otro"];

    return (
        <div className='h-screen antialiased bg-gray-200 pb-5 text-gray-800'>
            <NavigationBar />
            <div className="bg-white p-8 rounded-lg shadow-lg max-w-md mx-auto">
                <h1 className="font-bold text-center text-4xl text-blue-500">
                    Crear {''}
                    <span className="text-gray-800">Cuenta</span>
                </h1>
                <form onSubmit={handleSubmit}>
                    <div className='flex flex-col bg-gray-50 shadow p-10 rounded-lg space-y-6'>

                        <div className="flex flex-col space-y-1">
                            <input
                                type="text"
                                name="nombre"
                                value={formData.nombre}
                                onChange={handleChange}
                                className='appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 px-3 leading-tight focus:outline-none'
                                placeholder="Nombre"
                            />
                        </div>

                        <div className="flex flex-col space-y-1">
                            <input
                                type="text"
                                name="identidad"
                                value={formData.identidad}
                                onChange={handleChange}
                                className="appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 px-3 leading-tight focus:outline-none"
                                placeholder="Número de Identidad"
                            />
                        </div>

                        <div className="flex flex-col space-y-1">
                            <input
                                type="tel"
                                name="telefono"
                                value={formData.telefono}
                                onChange={handleChange}
                                className="appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 px-3 leading-tight focus:outline-none"
                                placeholder="Teléfono"
                            />
                        </div>

                        <div className="flex flex-col space-y-1">
                            <input
                                type="email"
                                name="correoElectronico"
                                value={formData.correoElectronico}
                                onChange={handleChange}
                                className="appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 px-3 leading-tight focus:outline-none"
                                placeholder="Correo Electrónico"
                            />
                        </div>

                        <div className="flex flex-col space-y-1 relative">
                            <select
                                name="genero"
                                value={formData.genero}
                                onChange={handleChange}
                                className="appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 pl-10 pr-3 leading-tight focus:outline-none"
                            >
                                <option className='text-gray-700' value="">Selecciona un género</option>
                                {generos.map((genero, index) => (
                                    <option key={index} value={genero}>{genero}</option>
                                ))}
                            </select>
                            <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                                <svg className="h-5 w-5 text-gray-500" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16M4 18h16" />
                                </svg>
                            </div>
                        </div>

                        <div className="flex flex-col space-y-1">
                            <input
                                type="password"
                                name="contraseña"
                                value={formData.contraseña}
                                onChange={handleChange}
                                className="appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 px-3 leading-tight focus:outline-none"
                                placeholder="Contraseña"
                            />
                        </div>

                        <div className="flex flex-col space-y-1">
                            <input
                                type="password"
                                name="repetirContraseña"
                                value={formData.repetirContraseña}
                                onChange={handleChange}
                                className="appearance-none bg-transparent border-b-2 border-blue-500 w-full text-gray-800 py-2 px-3 leading-tight focus:outline-none"
                                placeholder="Repetir Contraseña"
                            />
                        </div>

                        {errors.length > 0 && (
                            <div className="text-red-500">
                                <ul>
                                    {errors.map((error, index) => (
                                        <li key={index}>{error}</li>
                                    ))}
                                </ul>
                            </div>
                        )}

                        <div className='flex flex-col sm:flex-row justify-between content-center'>
                            <button
                                type="submit"
                                className="bg-blue-500 w-auto text-center text-white font-bold rounded focus:outline-none shadow hover:bg-blue-700 transition-colors px-5 py-2"
                            >
                                Crear Cuenta
                            </button>
                            <button
                                type="button"
                                onClick={() => navigate('/login')}
                                className="text-blue-500 font-bold mt-3 sm:mt-0"
                            >
                                Iniciar Sesión
                            </button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
};