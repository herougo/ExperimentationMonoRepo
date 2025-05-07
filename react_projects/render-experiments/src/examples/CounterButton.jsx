import React, { useState } from 'react';

const CounterButton = ({setCount, myData, onClick}) => {
    console.log('CounterButton render');
    let customOnClick = onClick;
    if (!customOnClick) {
        customOnClick = () => {
            setCount((count) => count+1);
        };
    }

    return (
        <button onClick={customOnClick}>Increment</button>
    );
};

export default CounterButton;