import React, { useCallback, useMemo, useState } from 'react';

const useDataMemo = () => {
    const [count, setCount] = useState(0);
    const [error, setError] = useState(0);

    const dependencies = [count, error];

    const onClick = useCallback(() => {
        setCount((count) => count+1)
    }, []);

    return useMemo(() => {
        return {
            count,
            error,
            onClick
        };
    }, dependencies);
};

export default useDataMemo;
