// User Model - Handles user data and business logic

export interface User {
  id: number
  email: string
  firstName?: string
  lastName?: string
  role: "jobseeker" | "employer" | "admin"
  profileImage?: string
  title?: string
  location?: string
  phone?: string
  bio?: string
  skills?: string[]
  experience?: Experience[]
  education?: Education[]
  savedJobs?: number[]
  appliedJobs?: number[]
}

export interface Experience {
  id: number
  company: string
  title: string
  startDate: string
  endDate?: string
  current: boolean
  description: string
}

export interface Education {
  id: number
  school: string
  degree: string
  startDate: string
  endDate: string
  description: string
}

// Mock data for users
const usersData: User[] = [
  {
    id: 1,
    email: "john.doe@example.com",
    firstName: "John",
    lastName: "Doe",
    role: "jobseeker",
    profileImage: "/placeholder.svg?height=100&width=100",
    title: "Software Developer",
    location: "San Francisco, CA",
    phone: "1234567890",
    bio: "Experienced software developer with a passion for building user-friendly applications.",
    skills: ["JavaScript", "React", "Node.js", "TypeScript", "HTML/CSS", "Git", "SQL", "MongoDB"],
    experience: [
      {
        id: 1,
        company: "TechCorp",
        title: "Senior Developer",
        startDate: "2020-01",
        endDate: "2023-01",
        current: false,
        description: "Led development of web applications using React and Node.js.",
      },
      {
        id: 2,
        company: "InnovateLabs",
        title: "Frontend Developer",
        startDate: "2018-03",
        current: true,
        description: "Building responsive web interfaces and implementing UI/UX designs.",
      },
    ],
    education: [
      {
        id: 1,
        school: "University of Technology",
        degree: "Bachelor of Science in Computer Science",
        startDate: "2014-09",
        endDate: "2018-05",
        description: "Graduated with honors. Specialized in web development and algorithms.",
      },
    ],
    savedJobs: [1, 3, 5],
    appliedJobs: [2, 4],
  },
  {
    id: 2,
    email: "techcorp@example.com",
    role: "employer",
    firstName: "Tech",
    lastName: "Corp",
    profileImage: "/placeholder.svg?height=100&width=100",
    title: "Technology Company",
    location: "San Francisco, CA",
    phone: "9876543210",
    bio: "A leading technology company specializing in software development and cloud solutions.",
  },
]

export class UserModel {
  // Get user by ID
  static getUserById(id: number): User | undefined {
    return usersData.find((user) => user.id === id)
  }

  // Get user by email
  static getUserByEmail(email: string): User | undefined {
    return usersData.find((user) => user.email === email)
  }

  // Create a new user
  static createUser(userData: Omit<User, "id">): User {
    const newUser = {
      id: Math.max(...usersData.map((user) => user.id)) + 1,
      ...userData,
    }

    usersData.push(newUser)
    return newUser
  }

  // Update user
  static updateUser(id: number, userData: Partial<User>): User | undefined {
    const userIndex = usersData.findIndex((user) => user.id === id)
    if (userIndex !== -1) {
      usersData[userIndex] = { ...usersData[userIndex], ...userData }
      return usersData[userIndex]
    }
    return undefined
  }

  // Save a job
  static saveJob(userId: number, jobId: number): User | undefined {
    const user = usersData.find((user) => user.id === userId)
    if (user) {
      if (!user.savedJobs) {
        user.savedJobs = []
      }
      if (!user.savedJobs.includes(jobId)) {
        user.savedJobs.push(jobId)
      }
    }
    return user
  }

  // Apply for a job
  static applyForJob(userId: number, jobId: number): User | undefined {
    const user = usersData.find((user) => user.id === userId)
    if (user) {
      if (!user.appliedJobs) {
        user.appliedJobs = []
      }
      if (!user.appliedJobs.includes(jobId)) {
        user.appliedJobs.push(jobId)
      }
    }
    return user
  }

  // Authenticate user (mock)
  static authenticateUser(email: string, password: string): User | null {
    // In a real app, you would verify the password hash
    const user = usersData.find((user) => user.email === email)
    return user || null
  }
}
