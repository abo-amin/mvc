// Post Model - Handles blog post data and business logic

export interface Author {
  id: number
  name: string
  avatar: string
  role: string
}

export interface Post {
  id: number
  title: string
  content: string
  excerpt: string
  author: Author
  category: string
  image: string
  date: string
  readTime: string
  likes: number
  comments: number
}

// Mock data for posts
const postsData: Post[] = [
  {
    id: 1,
    title: "10 Tips for a Successful Job Interview",
    content: "Prepare for your next job interview with these proven strategies...",
    excerpt:
      "Prepare for your next job interview with these proven strategies that will help you stand out from other candidates.",
    author: {
      id: 1,
      name: "Sarah Johnson",
      avatar: "/placeholder.svg?height=40&width=40",
      role: "Career Coach",
    },
    category: "Career Advice",
    image: "/placeholder.svg?height=200&width=400",
    date: "2023-05-15",
    readTime: "5 min read",
    likes: 124,
    comments: 32,
  },
  {
    id: 2,
    title: "How to Negotiate Your Salary Like a Pro",
    content: "Learn the art of salary negotiation with these expert tips...",
    excerpt:
      "Learn the art of salary negotiation with these expert tips that can help you secure the compensation you deserve.",
    author: {
      id: 2,
      name: "Michael Chen",
      avatar: "/placeholder.svg?height=40&width=40",
      role: "HR Specialist",
    },
    category: "Salary",
    image: "/placeholder.svg?height=200&width=400",
    date: "2023-06-02",
    readTime: "7 min read",
    likes: 98,
    comments: 45,
  },
  {
    id: 3,
    title: "The Future of Remote Work: Trends to Watch",
    content: "Explore the evolving landscape of remote work and discover the trends...",
    excerpt:
      "Explore the evolving landscape of remote work and discover the trends that will shape the future of how we work.",
    author: {
      id: 3,
      name: "Emily Rodriguez",
      avatar: "/placeholder.svg?height=40&width=40",
      role: "Workplace Strategist",
    },
    category: "Remote Work",
    image: "/placeholder.svg?height=200&width=400",
    date: "2023-04-28",
    readTime: "6 min read",
    likes: 156,
    comments: 29,
  },
  {
    id: 4,
    title: "Building a Professional LinkedIn Profile",
    content: "Optimize your LinkedIn presence with these proven strategies...",
    excerpt:
      "Optimize your LinkedIn presence with these proven strategies to attract recruiters and expand your professional network.",
    author: {
      id: 4,
      name: "David Wilson",
      avatar: "/placeholder.svg?height=40&width=40",
      role: "LinkedIn Expert",
    },
    category: "Networking",
    image: "/placeholder.svg?height=200&width=400",
    date: "2023-05-10",
    readTime: "8 min read",
    likes: 112,
    comments: 38,
  },
  {
    id: 5,
    title: "Transitioning to a Tech Career: A Complete Guide",
    content: "Looking to break into the tech industry? This comprehensive guide will show you how...",
    excerpt:
      "Looking to break into the tech industry? This comprehensive guide will show you how to make a successful career transition.",
    author: {
      id: 5,
      name: "Jessica Lee",
      avatar: "/placeholder.svg?height=40&width=40",
      role: "Tech Recruiter",
    },
    category: "Career Change",
    image: "/placeholder.svg?height=200&width=400",
    date: "2023-06-05",
    readTime: "10 min read",
    likes: 89,
    comments: 27,
  },
  {
    id: 6,
    title: "Mastering the Art of Networking in a Digital Age",
    content: "Discover effective strategies for building meaningful professional relationships...",
    excerpt:
      "Discover effective strategies for building meaningful professional relationships in today's increasingly digital world.",
    author: {
      id: 6,
      name: "Robert Taylor",
      avatar: "/placeholder.svg?height=40&width=40",
      role: "Networking Coach",
    },
    category: "Networking",
    image: "/placeholder.svg?height=200&width=400",
    date: "2023-05-22",
    readTime: "6 min read",
    likes: 76,
    comments: 19,
  },
]

export class PostModel {
  // Get all posts
  static getAllPosts(): Post[] {
    return postsData
  }

  // Get featured posts (limited number)
  static getFeaturedPosts(limit = 3): Post[] {
    return postsData.slice(0, limit)
  }

  // Get post by ID
  static getPostById(id: number): Post | undefined {
    return postsData.find((post) => post.id === id)
  }

  // Get posts by category
  static getPostsByCategory(category: string): Post[] {
    return postsData.filter((post) => post.category === category)
  }

  // Search posts
  static searchPosts(query = "", category = ""): Post[] {
    let filteredPosts = [...postsData]

    // Apply search query
    if (query) {
      const lowerCaseQuery = query.toLowerCase()
      filteredPosts = filteredPosts.filter(
        (post) =>
          post.title.toLowerCase().includes(lowerCaseQuery) ||
          post.content.toLowerCase().includes(lowerCaseQuery) ||
          post.excerpt.toLowerCase().includes(lowerCaseQuery),
      )
    }

    // Apply category filter
    if (category) {
      filteredPosts = filteredPosts.filter((post) => post.category === category)
    }

    return filteredPosts
  }

  // Create a new post
  static createPost(postData: Omit<Post, "id" | "likes" | "comments">): Post {
    const newPost = {
      id: Math.max(...postsData.map((post) => post.id)) + 1,
      ...postData,
      likes: 0,
      comments: 0,
    }

    postsData.push(newPost)
    return newPost
  }

  // Like a post
  static likePost(id: number): Post | undefined {
    const post = postsData.find((post) => post.id === id)
    if (post) {
      post.likes += 1
    }
    return post
  }
}
