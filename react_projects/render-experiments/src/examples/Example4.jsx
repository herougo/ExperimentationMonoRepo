import React, { useCallback, useMemo, useState } from 'react';
import CounterButton from './CounterButton';
import CounterText from './CounterText';
import CounterFooter from './CounterFooter';
import useData from './useData';

const CounterButtonMemo = React.memo(CounterButton);
const CounterTextMemo = React.memo(CounterText);
const CounterFooterMemo = React.memo(CounterFooter);


const Counter = ({myData}) => {
    console.log('Counter render');

    return (
        <div>
            <CounterTextMemo count={myData.count} />
            <CounterButtonMemo onClick={myData.onClick} />
            <CounterFooterMemo />
        </div>
    );
};

const CounterMemo = React.memo(Counter);

const CounterContainer = () => {
    console.log('CounterContainer render');
    const myData = useData();
    const [count2, setCount2] = useState(0);

    return (
        <div>
            <CounterMemo myData={myData}>
            </CounterMemo>
            <button onClick={() => setCount2(count => count+1)}>Change other state</button>
        </div>
    );
};

const Example4 = () => {
    console.log('Example4 render');
    return (
        <CounterContainer>
            
        </CounterContainer>
    );
}

export default Example4;
