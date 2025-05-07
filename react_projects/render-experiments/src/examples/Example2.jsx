import React, { useCallback, useMemo, useState } from 'react';
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
    const onClick = useCallback(() => setCount(count => count+1), []);

    return (
        <div>
            <CounterTextMemo count={count} />
            <CounterButtonMemo setCount={setCount} myData={myData} onClick={onClick} />
            <CounterFooterMemo />
        </div>
    );
};

const Example2 = () => {
    console.log('Example2 render');
    return (
        <div>
            <Counter />
        </div>
    );
};

export default Example2;
