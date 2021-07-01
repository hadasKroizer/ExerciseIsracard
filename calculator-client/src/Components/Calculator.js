import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Operator from './Operator';

import ReactDOM from 'react-dom';
import Button from '@material-ui/core/Button';

function Calculate() {
    const [num1, setNum1] = useState(null);
    const [num2, setNum2] = useState(null);
    const [operand, setOperand] = useState(1);
    const [result, setResult] = useState(null);
    const [history, setHistory] = useState([]);
    const [id, setId] = useState(null);


    const calculate = () => {
        console.log(num1, num2, operand);
        const data = {
            Number1: +num1,
            Number2: +num2,
            ExerciseOperator: +operand
        };
        if (id)
            data.ID = id;

        axios({
            url: '/calculator',
            method: id ? "PUT" : "POST",
            data: data
        })
            .then((response) => {
                const ex = response.data;
                setHistory([...history, ex]);
                setId(null);
                setResult(ex.result);
            }, (error) => {
                console.log(error);
            });
    }

    const update = (exercise) => {
        setNum1(exercise.number1);
        setNum2(exercise.number2);
        setOperand(exercise.exerciseOperator);
        setResult(exercise.result);
        setId(exercise.id)
    }

    const remove = (id) => {
        console.log(id)
        axios.delete(`/calculator/${id}`);
        setHistory(history.filter(e => e.id !== id));

    }
    useEffect(() =>
        axios.get('/calculator')
            .then((response) => {
                setHistory(response.data);
            }, (error) => {
                console.log(error);
            }), [])
    const mystyle = {
        margin: "20px",
        width: "50px",
    };
    return (
        <>
            <div>
                <input type="number" style={mystyle} onChange={(e) => setNum1(e.target.value)} value={num1}></input>
                <select onChange={(e) => setOperand(e.target.value)} value={operand}>
                    <option value="1">+</option>
                    <option value="2">-</option>
                    <option value="3">*</option>
                    <option value="4">/</option>
                </select>
                <input type="number" style={mystyle} onChange={(e) => setNum2(e.target.value)} value={num2}></input>
                <span onClick={calculate}>=</span>
                <span>{result}</span>
            </div>
            <div>
                {history.map(exercise =>
                (
                    <div>
                        <span style={{ padding: "10px" }}>
                            <span>{exercise.number1}</span>
                            <Operator>{exercise.exerciseOperator}</Operator>
                            <span>{exercise.number2}</span>
                            <span>=</span>
                            <span>{exercise.result}</span>
                        </span>
                        <button onClick={() => remove(exercise.id)}>Delete</button>
                        <button onClick={() => update(exercise)}>Update</button>
                    </div>
                ))
                }
            </div>
        </>
    );
}

export default Calculate;
