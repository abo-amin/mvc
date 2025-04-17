import { Filter, Search, MapPin } from "lucide-react"

import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Card, CardContent } from "@/components/ui/card"
import { Checkbox } from "@/components/ui/checkbox"
import { Label } from "@/components/ui/label"
import { Separator } from "@/components/ui/separator"
import { JobCard } from "@/views/components/job-card"

import type { Job } from "@/models/JobModel"

interface JobsViewProps {
  jobs: Job[]
}

export function JobsView({ jobs }: JobsViewProps) {
  return (
    <div className="container mx-auto px-4 py-12">
      <h1 className="mb-8 text-3xl font-bold">Find Your Perfect Job</h1>

      {/* Search Bar */}
      <div className="mb-8 flex flex-col gap-4 rounded-lg border bg-white p-6 shadow-sm md:flex-row">
        <div className="relative flex-1">
          <Search className="absolute left-3 top-3 h-5 w-5 text-gray-400" />
          <Input type="text" placeholder="Job title, keywords, or company" className="pl-10" />
        </div>
        <div className="relative flex-1">
          <MapPin className="absolute left-3 top-3 h-5 w-5 text-gray-400" />
          <Input type="text" placeholder="Location or remote" className="pl-10" />
        </div>
        <Button className="bg-emerald-600 hover:bg-emerald-700">Search Jobs</Button>
      </div>

      <div className="grid gap-8 md:grid-cols-[300px_1fr]">
        {/* Filters Sidebar */}
        <div className="space-y-6">
          <Card>
            <CardContent className="p-6">
              <div className="mb-4 flex items-center justify-between">
                <h2 className="text-lg font-semibold">Filters</h2>
                <Button variant="ghost" size="sm" className="h-auto p-0 text-emerald-600">
                  Clear All
                </Button>
              </div>

              {/* Job Type Filter */}
              <div className="space-y-4">
                <h3 className="font-medium">Job Type</h3>
                <div className="space-y-2">
                  <div className="flex items-center space-x-2">
                    <Checkbox id="full-time" />
                    <Label htmlFor="full-time">Full-time</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="part-time" />
                    <Label htmlFor="part-time">Part-time</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="contract" />
                    <Label htmlFor="contract">Contract</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="internship" />
                    <Label htmlFor="internship">Internship</Label>
                  </div>
                </div>
              </div>

              <Separator className="my-4" />

              {/* Experience Level Filter */}
              <div className="space-y-4">
                <h3 className="font-medium">Experience Level</h3>
                <div className="space-y-2">
                  <div className="flex items-center space-x-2">
                    <Checkbox id="entry-level" />
                    <Label htmlFor="entry-level">Entry Level</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="mid-level" />
                    <Label htmlFor="mid-level">Mid Level</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="senior-level" />
                    <Label htmlFor="senior-level">Senior Level</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="director" />
                    <Label htmlFor="director">Director</Label>
                  </div>
                </div>
              </div>

              <Separator className="my-4" />

              {/* Salary Range Filter */}
              <div className="space-y-4">
                <h3 className="font-medium">Salary Range</h3>
                <div className="space-y-2">
                  <div className="flex items-center space-x-2">
                    <Checkbox id="range-1" />
                    <Label htmlFor="range-1">$0 - $50K</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="range-2" />
                    <Label htmlFor="range-2">$50K - $100K</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="range-3" />
                    <Label htmlFor="range-3">$100K - $150K</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="range-4" />
                    <Label htmlFor="range-4">$150K+</Label>
                  </div>
                </div>
              </div>

              <Separator className="my-4" />

              {/* Remote Options Filter */}
              <div className="space-y-4">
                <h3 className="font-medium">Remote Options</h3>
                <div className="space-y-2">
                  <div className="flex items-center space-x-2">
                    <Checkbox id="remote-only" />
                    <Label htmlFor="remote-only">Remote Only</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="hybrid" />
                    <Label htmlFor="hybrid">Hybrid</Label>
                  </div>
                  <div className="flex items-center space-x-2">
                    <Checkbox id="on-site" />
                    <Label htmlFor="on-site">On-site</Label>
                  </div>
                </div>
              </div>

              <div className="mt-6">
                <Button className="w-full bg-emerald-600 hover:bg-emerald-700">Apply Filters</Button>
              </div>
            </CardContent>
          </Card>
        </div>

        {/* Job Listings */}
        <div className="space-y-6">
          <div className="flex items-center justify-between">
            <p className="text-slate-500">Showing {jobs.length} jobs</p>
            <div className="flex items-center gap-2">
              <Button variant="outline" size="sm">
                <Filter className="mr-2 h-4 w-4" />
                Sort by: Newest
              </Button>
            </div>
          </div>

          <div className="space-y-4">
            {jobs.map((job) => (
              <JobCard key={job.id} job={job} />
            ))}
          </div>

          <div className="mt-8 flex justify-center">
            <Button variant="outline" className="mx-1">
              1
            </Button>
            <Button variant="outline" className="mx-1">
              2
            </Button>
            <Button variant="outline" className="mx-1">
              3
            </Button>
            <Button variant="outline" className="mx-1">
              ...
            </Button>
            <Button variant="outline" className="mx-1">
              10
            </Button>
          </div>
        </div>
      </div>
    </div>
  )
}
