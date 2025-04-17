// Job Model - Handles job data and business logic

export interface Job {
  id: number
  title: string
  company: string
  logo: string
  location: string
  type: string
  salary: string
  posted: string
  description: string
  requirements?: string[]
  benefits?: string[]
}

// Mock data for jobs
const jobsData: Job[] = [
  {
    id: 1,
    title: "Senior Frontend Developer",
    company: "TechCorp",
    logo: "/placeholder.svg?height=40&width=40",
    location: "San Francisco, CA",
    type: "Full-time",
    salary: "$120K - $150K",
    posted: "2023-05-15",
    description: "We are looking for an experienced Frontend Developer to join our team...",
    requirements: [
      "5+ years of experience with React",
      "Strong understanding of JavaScript and TypeScript",
      "Experience with state management libraries",
      "Knowledge of responsive design and CSS frameworks",
    ],
    benefits: [
      "Competitive salary",
      "Health insurance",
      "401(k) matching",
      "Flexible work hours",
      "Remote work options",
    ],
  },
  {
    id: 2,
    title: "Product Manager",
    company: "InnovateLabs",
    logo: "/placeholder.svg?height=40&width=40",
    location: "New York, NY",
    type: "Full-time",
    salary: "$110K - $140K",
    posted: "2023-05-12",
    description: "Join our product team to lead the development of innovative solutions...",
    requirements: [
      "3+ years of product management experience",
      "Strong analytical and problem-solving skills",
      "Excellent communication and leadership abilities",
      "Experience with agile methodologies",
    ],
    benefits: [
      "Competitive salary",
      "Health and dental insurance",
      "Stock options",
      "Professional development budget",
      "Flexible work arrangements",
    ],
  },
  {
    id: 3,
    title: "UX/UI Designer",
    company: "DesignHub",
    logo: "/placeholder.svg?height=40&width=40",
    location: "Remote",
    type: "Contract",
    salary: "$80K - $100K",
    posted: "2023-05-16",
    description: "Looking for a creative designer to help shape our product experience...",
    requirements: [
      "Portfolio demonstrating UI/UX design skills",
      "Experience with design tools like Figma or Sketch",
      "Understanding of user-centered design principles",
      "Ability to create wireframes, prototypes, and high-fidelity designs",
    ],
    benefits: [
      "Competitive hourly rate",
      "Flexible schedule",
      "Remote work",
      "Opportunity for long-term collaboration",
    ],
  },
  {
    id: 4,
    title: "DevOps Engineer",
    company: "CloudSystems",
    logo: "/placeholder.svg?height=40&width=40",
    location: "Austin, TX",
    type: "Full-time",
    salary: "$130K - $160K",
    posted: "2023-05-10",
    description: "Help us build and maintain our cloud infrastructure and deployment pipelines...",
    requirements: [
      "Experience with AWS, Azure, or GCP",
      "Knowledge of containerization technologies like Docker and Kubernetes",
      "Familiarity with CI/CD pipelines",
      "Understanding of infrastructure as code",
    ],
    benefits: [
      "Competitive salary",
      "Comprehensive benefits package",
      "Remote work options",
      "Professional development opportunities",
      "Modern tech stack",
    ],
  },
  {
    id: 5,
    title: "Data Scientist",
    company: "AnalyticsPro",
    logo: "/placeholder.svg?height=40&width=40",
    location: "Chicago, IL",
    type: "Full-time",
    salary: "$125K - $155K",
    posted: "2023-05-08",
    description: "Join our data team to analyze complex datasets and build predictive models...",
    requirements: [
      "Advanced degree in Statistics, Mathematics, Computer Science, or related field",
      "Experience with Python, R, or similar data analysis tools",
      "Knowledge of machine learning algorithms",
      "Ability to communicate complex findings to non-technical stakeholders",
    ],
    benefits: [
      "Competitive salary",
      "Health and wellness benefits",
      "Flexible work arrangements",
      "Continuous learning opportunities",
      "Collaborative work environment",
    ],
  },
  {
    id: 6,
    title: "Backend Developer",
    company: "ServerTech",
    logo: "/placeholder.svg?height=40&width=40",
    location: "Seattle, WA",
    type: "Full-time",
    salary: "$115K - $145K",
    posted: "2023-05-14",
    description: "Looking for a skilled backend developer to build scalable APIs and services...",
    requirements: [
      "3+ years of experience with Node.js, Python, or Java",
      "Experience with database design and optimization",
      "Knowledge of RESTful API design principles",
      "Understanding of microservices architecture",
    ],
    benefits: [
      "Competitive salary",
      "Health and dental insurance",
      "401(k) matching",
      "Flexible work hours",
      "Remote work options",
    ],
  },
  {
    id: 7,
    title: "Marketing Specialist",
    company: "GrowthHackers",
    logo: "/placeholder.svg?height=40&width=40",
    location: "Remote",
    type: "Part-time",
    salary: "$60K - $80K",
    posted: "2023-05-13",
    description: "Help us grow our brand presence and acquire new customers through digital marketing...",
    requirements: [
      "2+ years of experience in digital marketing",
      "Proficiency with social media platforms and analytics tools",
      "Experience with content creation and SEO",
      "Strong analytical and communication skills",
    ],
    benefits: [
      "Competitive salary",
      "Flexible work schedule",
      "Remote work options",
      "Professional development opportunities",
      "Performance bonuses",
    ],
  },
  {
    id: 8,
    title: "Customer Success Manager",
    company: "ClientFirst",
    logo: "/placeholder.svg?height=40&width=40",
    location: "Boston, MA",
    type: "Full-time",
    salary: "$90K - $110K",
    posted: "2023-05-09",
    description: "Work with our enterprise clients to ensure they get maximum value from our platform...",
    requirements: [
      "3+ years of experience in customer success or account management",
      "Strong communication and relationship-building skills",
      "Problem-solving abilities and technical aptitude",
      "Experience with CRM software",
    ],
    benefits: [
      "Competitive salary",
      "Health and dental insurance",
      "401(k) matching",
      "Professional development budget",
      "Team events and activities",
    ],
  },
]

export class JobModel {
  // Get all jobs
  static getAllJobs(): Job[] {
    return jobsData
  }

  // Get featured jobs (limited number)
  static getFeaturedJobs(limit = 4): Job[] {
    return jobsData.slice(0, limit)
  }

  // Get job by ID
  static getJobById(id: number): Job | undefined {
    return jobsData.find((job) => job.id === id)
  }

  // Search jobs
  static searchJobs(query = "", filters: Record<string, any> = {}): Job[] {
    let filteredJobs = [...jobsData]

    // Apply search query
    if (query) {
      const lowerCaseQuery = query.toLowerCase()
      filteredJobs = filteredJobs.filter(
        (job) =>
          job.title.toLowerCase().includes(lowerCaseQuery) ||
          job.company.toLowerCase().includes(lowerCaseQuery) ||
          job.description.toLowerCase().includes(lowerCaseQuery) ||
          job.location.toLowerCase().includes(lowerCaseQuery),
      )
    }

    // Apply filters
    if (filters.type && filters.type.length > 0) {
      filteredJobs = filteredJobs.filter((job) => filters.type.includes(job.type))
    }

    if (filters.location && filters.location.length > 0) {
      filteredJobs = filteredJobs.filter((job) => filters.location.some((loc: string) => job.location.includes(loc)))
    }

    return filteredJobs
  }

  // Create a new job
  static createJob(jobData: Omit<Job, "id">): Job {
    const newJob = {
      id: Math.max(...jobsData.map((job) => job.id)) + 1,
      ...jobData,
    }

    jobsData.push(newJob)
    return newJob
  }
}
