// cambios echo en clase
import { useNavigate } from 'react-router-dom';
import { AuthContext } from './AuthContext'
//leer el localstorage este solo lee strings
const init = () => {
    const user = JSON.parse(localStorage.getItem('user'));

    return {
        logged: !!user,
        user: user,
    }
}

export const AuthProvider = ({ children }) => {
// esto sirve para que despues le pase los datos a los valores en el values
    const userPre = init();
    const navigate = useNavigate();

    const login = (user) => {
        localStorage.setItem('user', JSON.stringify(user));
        navigate('/');
    }

    const logout = () => {
        localStorage.removeItem('user')
    }

    return (
        <AuthContext.Provider value={{ ...userPre, login, logout }}>
            {children}
        </AuthContext.Provider>
    )
}