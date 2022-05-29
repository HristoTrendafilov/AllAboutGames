export const required = (message: string ) => (val: any): string => {

    if (val && typeof(val) == 'string' && isWhitespace(val)){
        return message;
    }
    if (val || val === 0 ) {
        return 'prazen';
    }
    else {
        return message;
    }

    function isWhitespace(input:string) {
        return input.trim()==='';
    }

};

export const validateUsername = (value: string) => {
    let error;
    if (value === 'admin') {
        error = 'Nice try!';
    }
    return error;
}