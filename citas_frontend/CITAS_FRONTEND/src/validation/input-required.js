export const InputRequiredValidation = (name, value) => { 
    // el id es para el input y el value es para el valor del input

    if (value.length == 0 || value === '') {
        return {

            validation: false,
            message: `${name} es requerido`
        
        }
    } 
    
    return {

        validation: true
    
    }
}