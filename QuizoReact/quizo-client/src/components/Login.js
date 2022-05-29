import { Button, Card, CardContent, TextField, Typography } from '@mui/material'
import { Box, width } from '@mui/system'
import React from 'react'
import Center from './Center'

export default function Login() {
    return (
        <Center>
            <Card sx={{ width: '400px' }}>
                <CardContent sx={{textAlign:'center'}}>
                    <Typography variant='h3' sx={{ my: 3 }}>Quizo</Typography>
                <Box sx={{
                    '& .MuiTextField-root': {
                        m: 1,
                        width: '90%'
                    }
                }}>
                    <form noValidate>
                        <TextField
                            label="Email"
                            name="email"
                            variant="outlined" />
                        <TextField
                            label="Name"
                            name="name"
                            variant="outlined" />
                        <Button
                            type="submit"
                            variant="contained"
                            size="large"
                            sx={{ width: '90%' ,
                            height: '50px'}}>Start</Button>
                    </form>
                </Box>
            </CardContent>
        </Card>
        </Center >


    )
}
