import React from 'react'
import { useState } from 'react'

const Select = (props) => {
    const { options, name, onChange, ...otherProps } = props
    const [optionsState, setOptionsState] = useState(options)

    
    return (
        <select {...otherProps} name={name} onChange={onChange}>
            {optionsState.map(option => <option key={option}>{option}</option>)}
        </select>
    )
}

export default Select
