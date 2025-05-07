import React, { useMemo, useState } from 'react';
import CounterButton from './CounterButton';
import CounterText from './CounterText';
import CounterFooter from './CounterFooter';

const CounterButtonMemo = React.memo(CounterButton);
const CounterTextMemo = React.memo(CounterText);
const CounterFooterMemo = React.memo(CounterFooter);

const Counter = () => {
    console.log('Counter render');
    const [count, setCount] = useState(0);
    const myData = useMemo(() => {return { 'hi': 'there' }}, []);

    return (
        <div>
            <CounterTextMemo count={count} />
            <CounterButtonMemo setCount={setCount} myData={myData} />
            <CounterFooterMemo />
        </div>
    );
};

const Example1 = () => {
    console.log('Example1 render');
    return (
        <div>
            <Counter />
        </div>
    );
};

export default Example1;
