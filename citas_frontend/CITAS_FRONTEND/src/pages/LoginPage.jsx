import { useContext, useState } from 'react';
import { InputEmailValidation } from '../validation/input-email';
import { InputRequiredValidation } from '../validation/input-required';
import { Error } from '../components';
import { NavigationBar } from '../components';
import { constants } from '../helpers/constants';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../context';

export const LoginPage = () => {
    const [loginForm, setLogin] = useState({
        email: '',
        password: '',
    });
    const [errors, setErrors] = useState([]);
    const { login } = useContext(AuthContext);
    const { API_URL } = constants();
    const navigate = useNavigate();

    const handleCreateAccount = () => {
        navigate('/register')
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        let newErrors = [];

        const errorEmail = InputEmailValidation('Correo Electrónico', loginForm.email);
        if (!errorEmail.validation) {
            newErrors.push(errorEmail.message)
        }

        const errorEmailRequired = InputRequiredValidation('Correo Electrónico', loginForm.email);
        if (!errorEmailRequired.validation) {
            newErrors.push(errorEmailRequired.message)
        }

        const errorPasswordRequired = InputRequiredValidation('Contraseña', loginForm.password);
        if (!errorPasswordRequired.validation) {
            newErrors.push(errorPasswordRequired.message)
        }

        setErrors(newErrors)

        if (newErrors.length === 0) {
            try {
                const response = await fetch(`${API_URL}/auth/login`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(loginForm),
                });

                if (!response.ok) {
                    throw new Error('Error al iniciar sesión')
                }
                const result = await response.json();
                login(result.data);

            } catch (error) {
                console.log(error);
            }
        }
    }

    return (
        <div>
            <NavigationBar />

            <div className="h-screen antialiased bg-gray-200 pb-5 text-gray-800">
                <div className="flex flex-col justify-center sm:w-96 sm:m-auto mx-5 space-y-8">
                    <h1 className="font-bold text-center text-4xl text-blue-500">
                        Agenda {''}
                        <span className="text-gray-800">Médica</span>
                    </h1>

                    <form onSubmit={handleSubmit}>
                        <div className="flex flex-col bg-gray-100 p-10 rounded-lg shadow space-y-6">
                            <h2 className="font-bold text-gray-800 text-xl text-center">
                                Iniciar Sesión
                            </h2>

                            {errors.length > 0 ? <Error errorList={errors} /> : null}
                            <div className="flex flex-col space-y-1 border-b-2 border-blue-500">
                                <input
                                    type="email"
                                    name="username"
                                    autoComplete='off'
                                    value={loginForm.email}
                                    onChange={(e) => setLogin({ ...loginForm, email: e.target.value })}
                                    required
                                    id='username'
                                    className='appearance-none bg-transparent border-none w-full text-gray-800 mr-3 py-1 px-2 leading-tight focus:outline-none'
                                    placeholder='Usuario'
                                />
                            </div>
                            <div className="flex flex-col space-y-1 border-b-2 border-blue-500">
                                <input
                                    value={loginForm.password}
                                    onChange={(e) => setLogin({ ...loginForm, password: e.target.value })}
                                    required
                                    type="password"
                                    name="password"
                                    id='password'
                                    className='appearance-none bg-transparent border-none w-full text-gray-800 mr-3 py-1 px-2 leading-tight focus:outline-none'
                                    placeholder='Contraseña'
                                />
                            </div>
                            <div className="flex flex-col-reverse sm:flex-row sm:justify-between content-center items-center">
                                <button
                                    type="submit"
                                    className="bg-blue-500 text-center w-auto text-white font-bold rounded focus:outline-none shadow hover:bg-blue-700 transition-colors px-5 py-2"
                                >
                                    Iniciar Sesión
                                </button>
                                <button
                                    type="button"
                                    onClick={handleCreateAccount}
                                    className="text-blue-500 font-bold mt-3 sm:mt-0"
                                >
                                    Crear Cuenta
                                </button>
                            </div>
                            <div className="text-center mt-2">
                                <button
                                    type="button"
                                    className="text-blue-500 font-bold"
                                >
                                    Olvidé mi Contraseña
                                </button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};
