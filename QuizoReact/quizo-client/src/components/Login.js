import { Button, Card, CardContent, TextField, Typography, CardActionArea } from '@mui/material'
import { Box, width } from '@mui/system'
import React, { useState } from 'react'
import Center from './Center'
import useForm from '../hooks/useForm'
import CardMedia from '@mui/material/CardMedia';

const getFreshModelObject = () => ({
    name: '',
    email: ''
})

export default function Login() {

    // Add validation
    const { values,
        setValues,
        errors,
        setErrors,
        handleInputChange } = useForm(getFreshModelObject);

    const login = e => {
        e.preventDefault();
        if (validate())
            console.log(values);
    }

    const validate = () => {
        let temp = {}
        temp.email = (/\S+@\S+\.\S+/).test(values.email) ? "" : "Email is not valid!"
        temp.name = values.name != "" ? "" : "This field is required."
        setErrors(temp)
        return Object.values(temp).every(x => x == "")
    }

    return (
        <Center>
            <Card sx={{ width: '400px' }}>
                <CardContent sx={{ textAlign: 'center' }}>
                    <CardMedia
                        component="img"
                        height="200"
                        image="https://i.ibb.co/sFGJFw7/quizo-logo.jpg"
                        alt="quizo-logo"
                    />
                    <Box sx={{
                        '& .MuiTextField-root': {
                            m: 1,
                            width: '90%'
                        }
                    }}>
                        <form noValidate autoComplete="off" onSubmit={login}>
                            <TextField
                                label="Email"
                                name="email"
                                value={values.email}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.email && { error: true, helperText: errors.email })}
                            />
                            <TextField
                                label="Name"
                                name="name"
                                value={values.name}
                                onChange={handleInputChange}
                                variant="outlined"
                                {...(errors.name && { error: true, helperText: errors.name })}
                            />
                            <Button
                                type="submit"
                                variant="contained"
                                size="large"
                                sx={{
                                    m: 1,
                                    width: '90%',
                                    height: '50px',
                                    bgcolor: 'primary',
                                }}>Start</Button>
                        </form>
                    </Box>
                </CardContent>
            </Card>
        </Center >


    )
}
