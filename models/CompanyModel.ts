// Company Model - Handles company data and business logic

export interface Company {
  id: number
  name: string
  logo: string
  industry: string
  location: string
  description: string
  website?: string
  founded: number
  size: string
  openPositions: number
}

// Mock data for companies
const companiesData: Company[] = [
  {
    id: 1,
    name: "TechCorp",
    logo: "/placeholder.svg?height=60&width=60",
    industry: "Technology",
    location: "San Francisco, CA",
    description: "A leading technology company specializing in software development and cloud solutions.",
    website: "https://techcorp.example.com",
    founded: 2010,
    size: "501-1000 employees",
    openPositions: 12,
  },
  {
    id: 2,
    name: "InnovateLabs",
    logo: "/placeholder.svg?height=60&width=60",
    industry: "Software",
    location: "New York, NY",
    description: "An innovative software company creating cutting-edge applications for businesses.",
    website: "https://innovatelabs.example.com",
    founded: 2015,
    size: "201-500 employees",
    openPositions: 8,
  },
  {
    id: 3,
    name: "DesignHub",
    logo: "/placeholder.svg?height=60&width=60",
    industry: "Design",
    location: "Remote",
    description: "A creative design agency working with clients worldwide to create stunning visual experiences.",
    website: "https://designhub.example.com",
    founded: 2018,
    size: "51-200 employees",
    openPositions: 5,
  },
  {
    id: 4,
    name: "CloudSystems",
    logo: "/placeholder.svg?height=60&width=60",
    industry: "Cloud Services",
    location: "Austin, TX",
    description: "Providing enterprise-grade cloud infrastructure and services to businesses of all sizes.",
    website: "https://cloudsystems.example.com",
    founded: 2012,
    size: "201-500 employees",
    openPositions: 10,
  },
  {
    id: 5,
    name: "FinTech Solutions",
    logo: "/placeholder.svg?height=60&width=60",
    industry: "Finance",
    location: "Chicago, IL",
    description: "Revolutionizing financial services with innovative technology solutions.",
    website: "https://fintechsolutions.example.com",
    founded: 2014,
    size: "51-200 employees",
    openPositions: 7,
  },
  {
    id: 6,
    name: "HealthPlus",
    logo: "/placeholder.svg?height=60&width=60",
    industry: "Healthcare",
    location: "Boston, MA",
    description: "Developing healthcare technology to improve patient outcomes and provider efficiency.",
    website: "https://healthplus.example.com",
    founded: 2016,
    size: "201-500 employees",
    openPositions: 9,
  },
]

export class CompanyModel {
  // Get all companies
  static getAllCompanies(): Company[] {
    return companiesData
  }

  // Get featured companies (limited number)
  static getFeaturedCompanies(limit = 6): Company[] {
    return companiesData.slice(0, limit)
  }

  // Get company by ID
  static getCompanyById(id: number): Company | undefined {
    return companiesData.find((company) => company.id === id)
  }

  // Search companies
  static searchCompanies(query = "", filters: Record<string, any> = {}): Company[] {
    let filteredCompanies = [...companiesData]

    // Apply search query
    if (query) {
      const lowerCaseQuery = query.toLowerCase()
      filteredCompanies = filteredCompanies.filter(
        (company) =>
          company.name.toLowerCase().includes(lowerCaseQuery) ||
          company.description.toLowerCase().includes(lowerCaseQuery) ||
          company.industry.toLowerCase().includes(lowerCaseQuery),
      )
    }

    // Apply filters
    if (filters.industry && filters.industry.length > 0) {
      filteredCompanies = filteredCompanies.filter((company) => filters.industry.includes(company.industry))
    }

    if (filters.location && filters.location.length > 0) {
      filteredCompanies = filteredCompanies.filter((company) =>
        filters.location.some((loc: string) => company.location.includes(loc)),
      )
    }

    return filteredCompanies
  }

  // Create a new company
  static createCompany(companyData: Omit<Company, "id">): Company {
    const newCompany = {
      id: Math.max(...companiesData.map((company) => company.id)) + 1,
      ...companyData,
    }

    companiesData.push(newCompany)
    return newCompany
  }
}
