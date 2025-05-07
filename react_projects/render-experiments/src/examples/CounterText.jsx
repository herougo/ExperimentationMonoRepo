import React, { useState } from 'react';

const CounterText = ({count}) => {
    console.log('CounterText render');
    return (
        <div>
            {count}
        </div>
    );
};

export default CounterText;