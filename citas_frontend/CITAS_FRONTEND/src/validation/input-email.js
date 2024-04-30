export const InputEmailValidation = (name, value) => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailRegex.test(value)) {
        return {
            validation : false,
            message: `${name} debe ser un correo electronico valido.` 
        }
    } else {
        return {
            validation : true
        }
    }
}