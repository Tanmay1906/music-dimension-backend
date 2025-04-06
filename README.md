# Music Dimension

A modern web application for exploring and experiencing music in a new dimension. Built with React and .NET 7.0.

## 🌟 Live Demo

- Frontend: [https://musicdimension-orcin.vercel.app](https://musicdimension-orcin.vercel.app)
- Backend API: [https://music-dimension-backend.onrender.com](https://music-dimension-backend.onrender.com)

## 🚀 Features

- User authentication (Register/Login)
- Interactive 3D music visualization
- Music streaming integration
- Playlist management
- Real-time audio processing

## 🛠️ Tech Stack

### Frontend
- React 18
- Three.js for 3D visualization
- Redux Toolkit for state management
- Framer Motion for animations
- Styled Components for styling
- Axios for API calls

### Backend
- .NET 7.0
- JWT Authentication
- Swagger/OpenAPI
- Docker containerization

## 📦 Installation

### Frontend Setup
```bash
# Navigate to frontend directory
cd music-dimension

# Install dependencies
npm install

# Start development server
npm start
```

### Backend Setup
```bash
# Navigate to backend directory
cd backend

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

## 🔧 Environment Variables

### Frontend (.env)
```
REACT_APP_API_URL=http://localhost:5000/api
```

### Backend (appsettings.json)
```json
{
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "your-issuer"
  }
}
```

## 🚀 Deployment

### Frontend (Vercel)
- Connect your GitHub repository to Vercel
- Set environment variables
- Deploy automatically with every push

### Backend (Render)
- Connect your GitHub repository to Render
- Set environment variables
- Uses Dockerfile for containerization

## 📝 API Documentation

API documentation is available at:
- Development: `http://localhost:5000`
- Production: [https://music-dimension-backend.onrender.com](https://music-dimension-backend.onrender.com)

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Tanmay** - *Initial work* - [Tanmay1906](https://github.com/Tanmay1906) 
