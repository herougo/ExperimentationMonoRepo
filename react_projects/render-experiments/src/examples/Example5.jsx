import React, { useCallback, useMemo, useState } from 'react';
import CounterButton from './CounterButton';
import CounterText from './CounterText';
import CounterFooter from './CounterFooter';
import useDataMemo from './useDataMemo';

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
    const myData = useDataMemo();
    const [count2, setCount2] = useState(0);

    return (
        <div>
            <CounterMemo myData={myData}>
            </CounterMemo>
            <button onClick={() => setCount2(count => count+1)}>Change other state</button>
        </div>
    );
};

const Example5 = () => {
    console.log('Example5 render');
    return (
        <CounterContainer>
            
        </CounterContainer>
    );
}

export default Example5;
