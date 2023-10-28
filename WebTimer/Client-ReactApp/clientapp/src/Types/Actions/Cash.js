export const AddCash = (cash) => {
    return {
        type:"Add",
        payload: cash
    }
}

export const AddAlarm = (date) => {
    return {
        type:"Add",
        payload:date
    }
}