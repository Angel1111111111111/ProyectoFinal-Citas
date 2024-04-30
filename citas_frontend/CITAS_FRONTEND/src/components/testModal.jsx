import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export const TestModal = () => {
    const [showModal, setShowModal] = useState(false)
    const [redirectToRegister, setRedirectToRegister] = useState(false);
    const [login, setLogin] = useState({
        email: '',
        password: '',
    });

    const [errors, setErrors] = useState([]);

    const navigate = useNavigate();
    console.log(errors.length);

    const handleSubmit = (e) => {
        e.preventDefault();

        let newErrors = [];

        const errorEmail = InputEmailValidation('Correo Electrónico', login.email);
        if (!errorEmail.validation) {
            newErrors.push(errorEmail.message)
        }

        const errorEmailRequired = InputRequiredValidation('Correo Electrónico', login.email);
        if (!errorEmailRequired.validation) {
            newErrors.push(errorEmailRequired.message)
        }

        const errorPasswordRequired = InputRequiredValidation('Contraseña', login.password);
        if (!errorPasswordRequired.validation) {
            newErrors.push(errorPasswordRequired.message)
        }

        setErrors(newErrors)

        console.log(errors);
        if (Object.entries(errors).length === 0) {
            console.log('No hay pedo');
            //navigate('/');
        }

        // if (errors.length === 0) {
        //     // Aquí iría la lógica para enviar los datos de inicio de sesión al backend
        //     navigate('/ruta-deseada');
        // }
    }
    const handleCreateAccount = () => {
        setRedirectToRegister(true);
    };

    if (redirectToRegister) {
        navigate('/register');
    }

    const handleForgotPassword = () => {
        // Aquí puedes implementar la lógica para redirigir al usuario a la página de recuperación de contraseña
        console.log('Redireccionar a la página de recuperación de contraseña');
    }

  return (
    <>
      <button
        className="inline-block tracking-tight text-xl px-4 py-2 leading-none rounded hover:text-gray-200 text-black mt-4 lg:mt-0 mr-4 font-semibold"
        type="button"
        onClick={() => setShowModal(true)}
      >
        Test
      </button>
      {showModal && (
        <div className="fixed inset-0 flex items-center justify-center bg-gray-900 bg-opacity-50 z-50">
          <div className="p-10 bg-gray-100 rounded-lg shadow w-96">
            {/* <h2 className="text-2xl font-semibold mb-4">Login</h2> */}
            <div>
                <div>
                    {/* <h1 className="font-bold text-center text-4xl text-blue-500">
                        Agenda {''}
                        <span className="text-gray-800">Médica</span>
                    </h1> */}

                    <form onSubmit={handleSubmit}>
                        <div className="flex flex-col rounded-lg space-y-6">
                            <h2 className="font-bold text-gray-800 text-xl text-center">
                                Inicio Sesión
                            </h2>

                            {errors.length > 0 ? <Error errorList={errors} /> : null}
                            <div className="flex flex-col space-y-1 border-b-2 border-blue-500">
                                <input
                                    type="email"
                                    name="username"
                                    autoComplete='off'
                                    value={login.email}
                                    onChange={(e) => setLogin({...login, email: e.target.value })} //cambios echo en clases
                                    //required
                                    id='username'
                                    className='appearance-none bg-transparent border-none w-full text-gray-800 mr-3 py-1 px-2 leading-tight focus:outline-none'
                                    placeholder='Correo Electrónico'
                                />
                            </div>
                            <div className="flex flex-col space-y-1 border-b-2 border-blue-500">
                                <input
                                    value={login.password}
                                    onChange={(e) => setLogin({...login, password: e.target.value})}
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
                                    onClick={handleForgotPassword}
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
        </div>
      )}
    </>
  );
}