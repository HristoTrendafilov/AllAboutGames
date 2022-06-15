import {useState} from "react";

const useLocalStorage = (key, initialValue) => {
    const [state, setState] = useState(() => {
        try {
            let item = localStorage.getItem(key);

            return item
                ? JSON.parse(item)
                : initialValue;
        } catch (err) {
            return initialValue;
        }
    });

    const setItem = (value) => {
        localStorage.setItem(key, JSON.stringify(value))
        setState(value);
    };

    return [
        state,
        setItem
    ];
};

export default useLocalStorage;
